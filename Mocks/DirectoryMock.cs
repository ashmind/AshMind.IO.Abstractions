using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AshMind.IO.Abstractions.Bases;
using AshMind.IO.Abstractions.Security;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Mocks {
    [PublicAPI]
    public class DirectoryMock : DirectoryBase, IEnumerable<IFileSystemInfo>, IDirectory {
        [NotNull] private readonly IList<IFileSystemInfo> _items = new List<IFileSystemInfo>();
        [CanBeNull] private string _fullName;

        public DirectoryMock([NotNull] string name, [NotNull] params IFileSystemInfo[] items) {
            Name = name;
            FullName = name;
            Extension = "";
            Exists = true;
            foreach (var item in items) {
                // ReSharper disable once AssignNullToNotNullAttribute
                AddInternal(item);
            }
        }

        public void Add([NotNull] IDirectory directory) {
            AddInternal(directory);
        }

        public void Add([NotNull] IFile file) {
            AddInternal(file);
        }

        private void AddInternal([NotNull] IFileSystemInfo item) {
            var file = item as FileMock;
            if (file != null)
                file.Directory = this;

            var directory = item as DirectoryMock;
            if (directory != null)
                directory.Parent = this;

            _items.Add(item);
        }

        public override IDirectory CreateSubdirectory(string path) {
            var directory = new DirectoryMock(Path.GetFileName(path)) {
                FullName = Path.Combine(this.FullName, path)
            };
            _items.Add(directory);
            return directory;
        }

        public override IDirectory CreateSubdirectory(string path, IDirectorySecurity directorySecurity) {
            return CreateSubdirectory(path);
        }

        public override void Create() {
            Exists = true;
        }

        public override void Create(IDirectorySecurity directorySecurity) {
            Exists = true;
        }
        
        public override IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption) {
            var patternRegex = new Regex(searchPattern.Replace("*", ".*").Replace("?", ".?"));
            // ReSharper disable once PossibleNullReferenceException
            return _items.Where(i => i.Exists && patternRegex.IsMatch(i.Name));
        }
        
        public override void Delete(bool recursive) {
            Exists = false;
            if (recursive) {
                foreach (var item in _items) {
                    item.Delete();
                }
            }
        }
        

        public new IDirectory Parent { get; set; }
        public new IDirectory Root { get; set; }

        public override IDirectory GetDirectory(string name, GetOption option = GetOption.Existing) {
            return GetItem<IDirectory>(name, option, () => new DirectoryMock(name) { Exists = false });
        }

        public override IFile GetFile(string name, GetOption option = GetOption.Existing) {
            return GetItem<IFile>(name, option, () => new FileMock(name, "") { Exists = false });
        }

        public override IFileSystemInfo GetFileSystemInfo(string name) {
            return GetItem<IFileSystemInfo>(name, GetOption.Existing, null);
        }

        private T GetItem<T>(string name, GetOption option, [CanBeNull] Func<T> defaultFactory) 
            where T: class, IFileSystemInfo
        {
            // ReSharper disable once PossibleNullReferenceException
            var existing = _items.OfType<T>().SingleOrDefault(i => i.Name == name);
            if (existing == null && option == GetOption.Existing)
                return null;

            // ReSharper disable once PossibleNullReferenceException
            return existing ?? defaultFactory();
        }

        public override void Refresh() {
        }

        public new string Extension { get; set; }
        public new string Name { get; set; }
        public new bool Exists { get; set; }

        public new string FullName {
            get {
                if (_fullName != null)
                    return _fullName;

                if (this.Parent == null)
                    return this.Name;

                return Path.Combine(this.Parent.FullName, this.Name);
            }
            set { _fullName = value; }
        }

        public override DateTime CreationTimeUtc { get; set; }
        public override DateTime LastAccessTimeUtc { get; set; }
        public override DateTime LastWriteTimeUtc { get; set; }
        public override FileAttributes Attributes { get; set; }

        #region IEnumerable<IFileSystemInfo> Members

        public IEnumerator<IFileSystemInfo> GetEnumerator() {
            return EnumerateFileSystemInfos().GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator System.Collections.IEnumerable.GetEnumerator() {
 	        return EnumerateFileSystemInfos().GetEnumerator();
        }

        #endregion
    }
}
