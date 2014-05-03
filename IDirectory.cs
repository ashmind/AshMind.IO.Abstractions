using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using AshMind.IO.Abstractions.Security;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions {
    [PublicAPI]
    public interface IDirectory : IFileSystemInfo {
        [NotNull] IDirectory CreateSubdirectory([NotNull] string path);
        [NotNull] IDirectory CreateSubdirectory([NotNull] string path, [NotNull] IDirectorySecurity directorySecurity);
        void Create();
        void Create([NotNull] IDirectorySecurity directorySecurity);
        [NotNull] IDirectorySecurity GetAccessControl();
        [NotNull] IDirectorySecurity GetAccessControl(AccessControlSections includeSections);
        void SetAccessControl([NotNull] IDirectorySecurity directorySecurity);
        [NotNull] IFile[] GetFiles([NotNull] string searchPattern);
        [NotNull] IFile[] GetFiles([NotNull] string searchPattern, SearchOption searchOption);
        [NotNull] IFile[] GetFiles();
        [NotNull] IDirectory[] GetDirectories();
        [NotNull] IFileSystemInfo[] GetFileSystemInfos([NotNull] string searchPattern);
        [NotNull] IFileSystemInfo[] GetFileSystemInfos([NotNull] string searchPattern, SearchOption searchOption);
        [NotNull] IFileSystemInfo[] GetFileSystemInfos();
        [NotNull] IDirectory[] GetDirectories([NotNull] string searchPattern);
        [NotNull] IDirectory[] GetDirectories([NotNull] string searchPattern, SearchOption searchOption);
        [NotNull] IEnumerable<IDirectory> EnumerateDirectories();
        [NotNull] IEnumerable<IDirectory> EnumerateDirectories([NotNull] string searchPattern);
        [NotNull] IEnumerable<IDirectory> EnumerateDirectories([NotNull] string searchPattern, SearchOption searchOption);
        [NotNull] IEnumerable<IFile> EnumerateFiles();
        [NotNull] IEnumerable<IFile> EnumerateFiles([NotNull] string searchPattern);
        [NotNull] IEnumerable<IFile> EnumerateFiles([NotNull] string searchPattern, SearchOption searchOption);
        [NotNull] IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos();
        [NotNull] IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos([NotNull] string searchPattern);
        [NotNull] IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos([NotNull] string searchPattern, SearchOption searchOption);
        void MoveTo([NotNull] string destDirName);
        void Delete(bool recursive);
        [CanBeNull] IDirectory Parent { get; }
        [CanBeNull] IDirectory Root { get; }

        [CanBeNull] IDirectory GetDirectory([NotNull] string name, GetOption option = GetOption.Always);
        [CanBeNull] IFile GetFile([NotNull] string name, GetOption option = GetOption.Always);
    }
}