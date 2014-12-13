using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AshMind.IO.Abstractions.Mocks.Internal;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Mocks {
    [PublicAPI]
    public class FileSystemMock : IFileSystem, IEnumerable<FileSystemInfoMock> {
        [NotNull] private readonly IList<FileSystemInfoMock> _items = new List<FileSystemInfoMock>();

        public FileSystemMock([NotNull] params FileSystemInfoMock[] items) {
            foreach (var item in items) {
                Add(item);
            }
        }

        public void Add([NotNull] FileSystemInfoMock fileSystemInfo) {
            MockHelper.Choose(fileSystemInfo, Add, Add);
        }

        public void Add([NotNull] FileMock file) {
            file.FileSystem = this;
            _items.Add(file);
        }

        public void Add([NotNull] DirectoryMock directory) {
            directory.FileSystem = this;
            _items.Add(directory);
        }

        internal void AddFileSystemInfoInternalWithoutSettingFileSystem([NotNull] FileSystemInfoMock fileSystemInfo) {
            _items.Add(fileSystemInfo);
        }

        [NotNull]
        public DirectoryMock GetDirectory([NotNull] string path) {
            return GetItem(path, new DirectoryMock(Path.GetFileName(path)));
        }

        [NotNull]
        public FileMock GetFile([NotNull] string path) {
            return GetItem(path, new FileMock(Path.GetFileName(path)));
        }

        [NotNull]
        public FileSystemInfoMock GetFileSystemInfo([NotNull] string path) {
            return GetItem(path, new FileSystemInfoMock(Path.GetFileName(path)));
        }

        [NotNull]
        private T GetItem<T>([NotNull] string path, [NotNull] T @default)
            where T : FileSystemInfoMock 
        {
            // ReSharper disable once PossibleNullReferenceException
            var existing = _items.OfType<T>().SingleOrDefault(i => i.FullName == path);
            if (existing != null)
                return existing;

            // ReSharper disable once PossibleNullReferenceException
            @default.FullName = path;
            @default.Exists = false;
            return @default;
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
