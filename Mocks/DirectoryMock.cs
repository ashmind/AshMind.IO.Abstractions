using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
                AddFileSystemInfo(item);
            }
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        public void AddFileSystemInfo([NotNull] FileSystemInfoMock fileSystemInfo) {
            var file = fileSystemInfo as FileMock;
            if (file != null) {
                AddFile(file);
                return;
            }

            var directory = fileSystemInfo as DirectoryMock;
            if (directory != null) {
                AddDirectory(directory);
                return;
            }

            throw new NotSupportedException("Item should be either FileMock or a DirectoryMock (received " + fileSystemInfo.GetType() + ").");
        }

        public void AddDirectory([NotNull] DirectoryMock directory) {
            directory.FileSystem = this.FileSystem;
            directory.Parent = this;
            _items.Add(directory);
        }

        public void AddFile([NotNull] FileMock file) {
            file.FileSystem = this.FileSystem;
            file.Directory = this;
            _items.Add(file);
        }
        
        public virtual IDirectory CreateSubdirectory(string path) {
            var directory = new DirectoryMock(Path.GetFileName(path)) {
                FullName = Path.Combine(this.FullName, path)
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
            }
        }

        public IDirectory Parent { get; set; }
        public IDirectory Root { get; set; }

        [NotNull]
        public DirectoryMock GetDirectory([NotNull] string name) {
            return GetItem(name, () => new DirectoryMock(name) { Exists = false });
        }

        [NotNull]
        public FileMock GetFile([NotNull] string name) {
            return GetItem(name, () => new FileMock(name, "") { Exists = false });
        }

        [NotNull]
        public FileSystemInfoMock GetFileSystemInfo([NotNull] string name) {
            return GetItem(name, () => new FileSystemInfoMock(name) { Exists = false });
        }

        [NotNull]
        private T GetItem<T>(string name, [NotNull] Func<T> defaultFactory)
            where T : FileSystemInfoMock
        {
            // ReSharper disable once PossibleNullReferenceException
            var existing = _items.OfType<T>().SingleOrDefault(i => i.Name == name);

            // ReSharper disable once PossibleNullReferenceException
            // ReSharper disable once AssignNullToNotNullAttribute
            return existing ?? defaultFactory();
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

        public IFile[] GetFiles() {
            throw new NotImplementedException();
        }

        public IFile[] GetFiles(string searchPattern) {
            throw new NotImplementedException();
        }

        public IFile[] GetFiles(string searchPattern, SearchOption searchOption) {
            throw new NotImplementedException();
        }

        public IDirectory[] GetDirectories() {
            throw new NotImplementedException();
        }

        public IDirectory[] GetDirectories(string searchPattern) {
            throw new NotImplementedException();
        }

        public IDirectory[] GetDirectories(string searchPattern, SearchOption searchOption) {
            throw new NotImplementedException();
        }

        public IFileSystemInfo[] GetFileSystemInfos() {
            throw new NotImplementedException();
        }

        public IFileSystemInfo[] GetFileSystemInfos(string searchPattern) {
            throw new NotImplementedException();
        }

        public IFileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption) {
            throw new NotImplementedException();
        }

        public IEnumerable<IFile> EnumerateFiles() {
            throw new NotImplementedException();
        }

        public IEnumerable<IFile> EnumerateFiles(string searchPattern) {
            throw new NotImplementedException();
        }

        public IEnumerable<IFile> EnumerateFiles(string searchPattern, SearchOption searchOption) {
            throw new NotImplementedException();
        }

        public IEnumerable<IDirectory> EnumerateDirectories() {
            throw new NotImplementedException();
        }

        public IEnumerable<IDirectory> EnumerateDirectories(string searchPattern) {
            throw new NotImplementedException();
        }

        public IEnumerable<IDirectory> EnumerateDirectories(string searchPattern, SearchOption searchOption) {
            throw new NotImplementedException();
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

        public void MoveTo(string destDirName) {
            throw new NotImplementedException();
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
