using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.IO.Abstractions.Adapters {
    public class FileSystem : IFileSystem {
        public virtual IDirectory GetDirectory(string path, GetOption option = GetOption.Always) {
            return AdapterHelper.GetDirectory(path, option);
        }

        public virtual IFile GetFile(string path, GetOption option = GetOption.Always) {
            return AdapterHelper.GetFile(path, option);
        }
    }
}
