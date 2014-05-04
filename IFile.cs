using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text;
using AshMind.IO.Abstractions.Security;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions {
    [PublicAPI]
    public interface IFile : IFileSystemInfo {
        // basic FileInfo methods
        [NotNull] IFileSecurity GetAccessControl();
        [NotNull] IFileSecurity GetAccessControl(AccessControlSections includeSections);
        void SetAccessControl([NotNull] IFileSecurity fileSecurity);
        [NotNull] StreamReader OpenText();
        [NotNull] StreamWriter CreateText();
        [NotNull] StreamWriter AppendText();
        [NotNull] IFile CopyTo([NotNull] string destFileName);
        [NotNull] IFile CopyTo([NotNull] string destFileName, bool overwrite);
        [NotNull] Stream Create();
        void Decrypt();
        void Encrypt();
        [NotNull] Stream Open(FileMode mode);
        [NotNull] Stream Open(FileMode mode, FileAccess access);
        [NotNull] Stream Open(FileMode mode, FileAccess access, FileShare share);
        [NotNull] Stream OpenRead();
        [NotNull] Stream OpenWrite();
        void MoveTo([NotNull] string destFileName);
        [NotNull] IFile Replace([NotNull] string destinationFileName, [NotNull] string destinationBackupFileName);
        [NotNull] IFile Replace([NotNull] string destinationFileName, [NotNull] string destinationBackupFileName, bool ignoreMetadataErrors);
        long Length { get; }
        [CanBeNull] string DirectoryName { get; }
        [CanBeNull] IDirectory Directory { get; }
        bool IsReadOnly { get; set; }

        // File helpers
        [NotNull] string ReadAllText();
        [NotNull] string ReadAllText([NotNull] Encoding encoding);
        [NotNull] string[] ReadAllLines();
        [NotNull] string[] ReadAllLines([NotNull] Encoding encoding);
        [NotNull] byte[] ReadAllBytes();

        void WriteAllText([CanBeNull] string contents);
        void WriteAllText([CanBeNull] string contents, [NotNull] Encoding encoding);
        void WriteAllLines([NotNull] string[] contents);
        void WriteAllLines([NotNull] string[] contents, [NotNull] Encoding encoding);
        #if NET40
        void WriteAllLines([NotNull] IEnumerable<string> contents);
        void WriteAllLines([NotNull] IEnumerable<string> contents, [NotNull] Encoding encoding);
        #endif
        void WriteAllBytes([NotNull] byte[] bytes);
        void AppendAllText([CanBeNull] string contents);
        void AppendAllText([CanBeNull] string contents, [NotNull] Encoding encoding);
        #if NET40
        void AppendAllLines([NotNull] string[] contents);
        void AppendAllLines([NotNull] string[] contents, [NotNull] Encoding encoding);
        void AppendAllLines([NotNull] IEnumerable<string> contents);
        void AppendAllLines([NotNull] IEnumerable<string> contents, [NotNull] Encoding encoding);
        #endif
    }
}