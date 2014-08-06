using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AshMind.IO.Abstractions.Bases;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Mocks {
    [PublicAPI]
    public class FileSystemMock : FileSystemBase, IFileSystem, IEnumerable<IFileSystemInfo> {
        [NotNull] private readonly IList<IFileSystemInfo> _items = new List<IFileSystemInfo>();

        public override IDirectory GetDirectory(string path, GetOption option = GetOption.Existing) {
            var item = _items.OfType<IDirectory>().SingleOrDefault(i => i.FullName == path);
            if (item != null || option == GetOption.Existing)
                return item;

            return new DirectoryMock(Path.GetFileName(path)) { FullName = path, Exists = false };
        }

        public override IFile GetFile(string path, GetOption option = GetOption.Existing) {
            var item = _items.OfType<IFile>().SingleOrDefault(i => i.FullName == path);
            if (item != null || option == GetOption.Existing)
                return item;

            return new FileMock(Path.GetFileName(path), "") { FullName = path, Exists = false };
        }

        public override IFileSystemInfo GetFileSystemInfo(string path) {
            return _items.SingleOrDefault(i => i.FullName == path);
        }

        #region IEnumerable<IFileSystemInfo> Members

        public IEnumerator<IFileSystemInfo> GetEnumerator() {
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
