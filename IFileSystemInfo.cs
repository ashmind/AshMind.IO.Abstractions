using System;
using System.IO;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions {
    [PublicAPI]
    public interface IFileSystemInfo {
        [NotNull] string Name { get; }
        [NotNull] string Extension { get; }
        [NotNull] string FullName { get; }
        bool Exists { get; }
        DateTime CreationTime { get; set; }
        DateTime CreationTimeUtc { get; set; }
        DateTime LastAccessTime { get; set; }
        DateTime LastAccessTimeUtc { get; set; }
        DateTime LastWriteTime { get; set; }
        DateTime LastWriteTimeUtc { get; set; }
        FileAttributes Attributes { get; set; }

        void Delete();
        void Refresh();
    }
}