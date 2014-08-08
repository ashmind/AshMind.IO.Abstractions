using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions {
    [PublicAPI]
    public interface IFileSystem {
        [PublicAPI, NotNull] IDirectory GetDirectory([NotNull] string path);
        [PublicAPI, NotNull] IFile GetFile([NotNull] string path);
        [PublicAPI, NotNull] IFileSystemInfo GetFileSystemInfo([NotNull] string path);
    }
}