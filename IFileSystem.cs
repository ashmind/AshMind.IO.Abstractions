using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions {
    public interface IFileSystem {
        [CanBeNull] IDirectory GetDirectory([NotNull] string path, GetOption option = GetOption.Always);
        [CanBeNull] IFile GetFile([NotNull] string path, GetOption option = GetOption.Always);
    }
}
