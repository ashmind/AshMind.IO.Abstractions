using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        [NotNull]
        public DirectoryMock GetDirectory([NotNull] string path) {
            // ReSharper disable once PossibleNullReferenceException
            var item = _items.OfType<DirectoryMock>().SingleOrDefault(i => i.FullName == path);
            return item ?? new DirectoryMock(Path.GetFileName(path)) { FullName = path, Exists = false };
        }

        [NotNull]
        public FileMock GetFile([NotNull] string path) {
            // ReSharper disable once PossibleNullReferenceException
            var item = _items.OfType<FileMock>().SingleOrDefault(i => i.FullName == path);
            return item ?? new FileMock(Path.GetFileName(path), "") { FullName = path, Exists = false };
        }

        [NotNull]
        public FileSystemInfoMock GetFileSystemInfo([NotNull] string path) {
            // ReSharper disable once PossibleNullReferenceException
            var item = _items.SingleOrDefault(i => i.FullName == path);
            return item ?? new FileSystemInfoMock(Path.GetFileName(path)) { FullName = path, Exists = false };
        }

        IDirectory IFileSystem.GetDirectory(string path) {
            return GetDirectory(path);
        }

        IFile IFileSystem.GetFile(string path) {
            return GetFile(path);
        }

        IFileSystemInfo IFileSystem.GetFileSystemInfo(string path) {
            return GetFileSystemInfo(path);
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
