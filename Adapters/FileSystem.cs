using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.IO.Abstractions.Adapters {
    public class FileSystem : IFileSystem {
        public virtual IDirectory GetDirectory(string path) {
            return AdapterHelper.GetDirectory(path);
        }

        public virtual IFile GetFile(string path) {
            return AdapterHelper.GetFile(path);
        }

        public IFileSystemInfo GetFileSystemInfo(string path) {
            return AdapterHelper.GetFileSystemInfo(path);
        }
    }
}
