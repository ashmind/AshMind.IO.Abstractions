using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AshMind.IO.Abstractions.Mocks.Internal;
using AshMind.IO.Abstractions.Security;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Mocks {
    [PublicAPI]
    public class DirectoryMock : FileSystemInfoMock, IDirectory, IEnumerable<FileSystemInfoMock> {
        [NotNull] private readonly IList<FileSystemInfoMock> _items = new List<FileSystemInfoMock>();
        [CanBeNull] private string _fullName;

        public DirectoryMock([NotNull] params FileSystemInfoMock[] items) : this("", items) {
        }

        public DirectoryMock([NotNull] string name, [NotNull] params FileSystemInfoMock[] items) {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Name = name;
            FullName = name;
            Extension = "";
            Exists = true;
            foreach (var item in items) {
                // ReSharper disable once AssignNullToNotNullAttribute
                Add(item);
            }
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        public override FileSystemMock FileSystem {
            get {
                if (base.FileSystem != null)
                    return base.FileSystem;

                if (this.Parent != null)
                    return Parent.FileSystem;

                return null;
            }
            set { base.FileSystem = value; }
        }

        public void Add([NotNull] FileSystemInfoMock fileSystemInfo) {
            MockHelper.Choose(fileSystemInfo, Add, Add);
        }

        public void Add([NotNull] DirectoryMock directory) {
            directory.Parent = this;
            _items.Add(directory);
        }

        public void Add([NotNull] FileMock file) {
            file.Directory = this;
            _items.Add(file);
        }
        
        public virtual IDirectory CreateSubdirectory(string path) {
            var directory = new DirectoryMock(Path.GetFileName(path)) {
                FullName = Path.Combine(this.FullName, path),
                Parent = this
            };
            _items.Add(directory);
            return directory;
        }

        public virtual IDirectory CreateSubdirectory(string path, IDirectorySecurity directorySecurity) {
            return CreateSubdirectory(path);
        }

        public virtual void Create() {
            Exists = true;
        }

        public virtual void Create(IDirectorySecurity directorySecurity) {
            Exists = true;
        }
        
        public void Delete(bool recursive) {
            Exists = false;
            if (recursive) {
                foreach (var item in _items) {
                    // ReSharper disable once PossibleNullReferenceException
                    item.Delete();
                }
                _items.Clear();
            }
        }

        public DirectoryMock Parent { get; set; }
        public DirectoryMock Root { get; set; }

        [NotNull]
        public DirectoryMock GetDirectory([NotNull] string name) {
            return GetItem(name, () => new DirectoryMock(name));
        }

        [NotNull]
        public FileMock GetFile([NotNull] string name) {
            return GetItem(name, () => new FileMock(name));
        }

        [NotNull]
        public FileSystemInfoMock GetFileSystemInfo([NotNull] string name) {
            return GetItem(name, () => new FileSystemInfoMock(name));
        }

        [NotNull]
        private T GetItem<T>(string name, [NotNull] Func<T> defaultFactory)
            where T : FileSystemInfoMock
        {
            // ReSharper disable once PossibleNullReferenceException
            var existing = _items.OfType<T>().SingleOrDefault(i => i.Name == name);
            if (existing != null)
                return existing;

            var @default = defaultFactory();
            // ReSharper disable once PossibleNullReferenceException
            @default.Exists = false;
            return @default;
        }
        
        public override string FullName {
            get {
                if (_fullName != null)
                    return _fullName;

                if (this.Parent == null)
                    return this.Name;

                return Path.Combine(this.Parent.FullName, this.Name);
            }
            set { _fullName = value; }
        }

        public IDirectorySecurity GetAccessControl() {
            throw new NotImplementedException();
        }

        public IDirectorySecurity GetAccessControl(System.Security.AccessControl.AccessControlSections includeSections) {
            throw new NotImplementedException();
        }

        public void SetAccessControl(IDirectorySecurity directorySecurity) {
            throw new NotImplementedException();
        }

        [NotNull]
        public FileMock[] GetFiles() {
            return EnumerateFiles().ToArray();
        }

        [NotNull]
        public DirectoryMock[] GetDirectories() {
            return EnumerateDirectories().ToArray();
        }

        [NotNull]
        public FileSystemInfoMock[] GetFileSystemInfos() {
            return EnumerateFileSystemInfos().ToArray();
        }

        [NotNull]
        public IEnumerable<FileMock> EnumerateFiles() {
            return EnumerateFileSystemInfos().OfType<FileMock>();
        }

        [NotNull]
        public IEnumerable<DirectoryMock> EnumerateDirectories() {
            return EnumerateFileSystemInfos().OfType<DirectoryMock>();
        }

        [NotNull]
        public IEnumerable<FileSystemInfoMock> EnumerateFileSystemInfos() {
            return _items;
        }

        public void MoveTo(string destDirName) {
            throw new NotImplementedException();
        }

        #region IDirectory Members

        IDirectory IDirectory.Root {
            get { return Root; }
        }

        IDirectory IDirectory.Parent {
            get { return Parent; }
        }

        IFile[] IDirectory.GetFiles() {
            return ((IDirectory)this).EnumerateFiles().ToArray();
        }

        IFile[] IDirectory.GetFiles(string searchPattern) {
            return ((IDirectory)this).EnumerateFiles(searchPattern).ToArray();
        }

        IFile[] IDirectory.GetFiles(string searchPattern, SearchOption searchOption) {
            return ((IDirectory)this).EnumerateFiles(searchPattern, searchOption).ToArray();
        }

        IDirectory[] IDirectory.GetDirectories() {
            return ((IDirectory)this).EnumerateDirectories().ToArray();
        }

        IDirectory[] IDirectory.GetDirectories(string searchPattern) {
            return ((IDirectory)this).EnumerateDirectories(searchPattern).ToArray();
        }

        IDirectory[] IDirectory.GetDirectories(string searchPattern, SearchOption searchOption) {
            return ((IDirectory)this).EnumerateDirectories(searchPattern, searchOption).ToArray();
        }

        IFileSystemInfo[] IDirectory.GetFileSystemInfos() {
            return ((IDirectory)this).EnumerateFileSystemInfos().ToArray();
        }

        IFileSystemInfo[] IDirectory.GetFileSystemInfos(string searchPattern) {
            return ((IDirectory)this).EnumerateFileSystemInfos(searchPattern).ToArray();
        }

        IFileSystemInfo[] IDirectory.GetFileSystemInfos(string searchPattern, SearchOption searchOption) {
            return ((IDirectory)this).EnumerateFileSystemInfos(searchPattern, searchOption).ToArray();
        }

        IEnumerable<IFile> IDirectory.EnumerateFiles() {
            return ((IDirectory)this).EnumerateFileSystemInfos().OfType<IFile>();
        }

        IEnumerable<IFile> IDirectory.EnumerateFiles(string searchPattern) {
            return ((IDirectory)this).EnumerateFileSystemInfos(searchPattern).OfType<IFile>();
        }

        IEnumerable<IFile> IDirectory.EnumerateFiles(string searchPattern, SearchOption searchOption) {
            return ((IDirectory)this).EnumerateFileSystemInfos(searchPattern, searchOption).OfType<IFile>();
        }

        IEnumerable<IDirectory> IDirectory.EnumerateDirectories() {
            return ((IDirectory)this).EnumerateFileSystemInfos().OfType<IDirectory>();
        }

        IEnumerable<IDirectory> IDirectory.EnumerateDirectories(string searchPattern) {
            return ((IDirectory)this).EnumerateFileSystemInfos(searchPattern).OfType<IDirectory>();
        }

        IEnumerable<IDirectory> IDirectory.EnumerateDirectories(string searchPattern, SearchOption searchOption) {
            return ((IDirectory)this).EnumerateFileSystemInfos(searchPattern, searchOption).OfType<IDirectory>();
        }

        IEnumerable<IFileSystemInfo> IDirectory.EnumerateFileSystemInfos() {
            return ((IDirectory)this).EnumerateFileSystemInfos("*", SearchOption.TopDirectoryOnly);
        }

        IEnumerable<IFileSystemInfo> IDirectory.EnumerateFileSystemInfos(string searchPattern) {
            return ((IDirectory)this).EnumerateFileSystemInfos(searchPattern, SearchOption.TopDirectoryOnly);
        }

        IEnumerable<IFileSystemInfo> IDirectory.EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption) {
            var patternRegex = new Regex(searchPattern.Replace("*", ".*").Replace("?", ".?"));
            // ReSharper disable once PossibleNullReferenceException
            return _items.Where(i => i.Exists && patternRegex.IsMatch(i.Name));
        }
        
        IDirectory IDirectory.GetDirectory(string name) {
            return this.GetDirectory(name);
        }

        IFile IDirectory.GetFile(string name) {
            return this.GetFile(name);
        }

        IFileSystemInfo IDirectory.GetFileSystemInfo(string name) {
            return this.GetFileSystemInfo(name);
        }

        #endregion

        #region IEnumerable<FileSystemInfoMock> Members

        public IEnumerator<FileSystemInfoMock> GetEnumerator() {
            return _items.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator() {
 	        return GetEnumerator();
        }

        #endregion
    }
}
