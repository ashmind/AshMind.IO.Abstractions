using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions {
    [PublicAPI]
    public interface IFileSystem {
        [PublicAPI, CanBeNull] IDirectory GetDirectory([NotNull] string path, GetOption option = GetOption.Existing);
        [PublicAPI, CanBeNull] IFile GetFile([NotNull] string path, GetOption option = GetOption.Existing);
        [PublicAPI, CanBeNull] IFileSystemInfo GetFileSystemInfo([NotNull] string path);
    }
}