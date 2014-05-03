using System;
using System.IO;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions {
    [PublicAPI]
    public interface IFileSystemInfo {
        void Delete();
        void Refresh();
        [NotNull] string Extension { get; }
        [NotNull] string FullName { get; }
        [NotNull] string Name { get; }
        bool Exists { get; }
        DateTime CreationTimeUtc { get; set; }
        DateTime CreationTime { get; set; }
        DateTime LastAccessTime { get; set; }
        DateTime LastAccessTimeUtc { get; set; }
        DateTime LastWriteTime { get; set; }
        DateTime LastWriteTimeUtc { get; set; }
        FileAttributes Attributes { get; set; }
    }
}