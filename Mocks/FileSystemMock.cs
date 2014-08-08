using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AshMind.IO.Abstractions.Bases;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Mocks {
    [PublicAPI]
    public class FileSystemMock : IFileSystem, IEnumerable<FileSystemInfoMock> {
        [NotNull] private readonly IList<FileSystemInfoMock> _items = new List<FileSystemInfoMock>();

        public void AddFile([NotNull] FileMock file) {
            file.FileSystem = this;
            file.Directory = null;
            _items.Add(file);
        }

        internal void AddFileSystemInfoInternalWithoutSettingFileSystem([NotNull] FileSystemInfoMock fileSystemInfo) {
            _items.Add(fileSystemInfo);
        }

        public DirectoryMock GetDirectory(string path, GetOption option = GetOption.Existing) {
            var item = _items.OfType<DirectoryMock>().SingleOrDefault(i => i.FullName == path);
            if (item != null || option == GetOption.Existing)
                return item;

            return new DirectoryMock(Path.GetFileName(path)) { FullName = path, Exists = false };
        }

        public FileMock GetFile(string path, GetOption option = GetOption.Existing) {
            var item = _items.OfType<FileMock>().SingleOrDefault(i => i.FullName == path);
            if (item != null || option == GetOption.Existing)
                return item;

            return new FileMock(Path.GetFileName(path), "") { FullName = path, Exists = false };
        }

        public FileSystemInfoMock GetFileSystemInfo(string path, GetOption option = GetOption.Existing) {
            var item = _items.SingleOrDefault(i => i.FullName == path);
            if (item != null || option == GetOption.Existing)
                return item;

            return new FileSystemInfoMock(Path.GetFileName(path)) { FullName = path, Exists = false };
        }

        IDirectory IFileSystem.GetDirectory(string path, GetOption option = GetOption.Existing) {
            return GetDirectory(path, option);
        }

        IFile IFileSystem.GetFile(string path, GetOption option = GetOption.Existing) {
            return GetFile(path, option);
        }

        IFileSystemInfo IFileSystem.GetFileSystemInfo(string path, GetOption option = GetOption.Existing) {
            return GetFileSystemInfo(path, option);
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
