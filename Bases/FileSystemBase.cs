using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.IO.Abstractions.Bases {
    public abstract class FileSystemBase : IFileSystem {
        public virtual IDirectory GetDirectory(string path) {
            throw new NotImplementedException();
        }

        public virtual IFile GetFile(string path) {
            throw new NotImplementedException();
        }

        public virtual IFileSystemInfo GetFileSystemInfo(string path) {
            throw new NotImplementedException();
        }
    }
}
