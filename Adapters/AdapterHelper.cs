using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using AshMind.IO.Abstractions.Security;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Adapters {
    internal static class AdapterHelper {
        [ContractAnnotation("directoryInfo:null=>null")]
        public static IDirectory Adapt(DirectoryInfo directoryInfo) {
            if (directoryInfo == null)
                return null;

            return new DirectoryInfoAdapter(directoryInfo);
        }

        [ContractAnnotation("fileInfo:null=>null")]
        public static IFile Adapt(FileInfo fileInfo) {
            if (fileInfo == null)
                return null;
            return new FileInfoAdapter(fileInfo);
        }
        
        [ContractAnnotation("fileSystemInfo:null=>null")]
        public static IFileSystemInfo Adapt(FileSystemInfo fileSystemInfo) {
            if (fileSystemInfo == null)
                return null;

            var fileInfo = fileSystemInfo as FileInfo;
            if (fileInfo != null)
                return new FileInfoAdapter(fileInfo);

            var directoryInfo = fileSystemInfo as DirectoryInfo;
            if (directoryInfo != null)
                return new DirectoryInfoAdapter(directoryInfo);

            throw new NotSupportedException("Type " + fileSystemInfo.GetType() + " can not be adapted.");
        }

        [ContractAnnotation("directorySecurity:null=>null")]
        public static IDirectorySecurity Adapt(DirectorySecurity directorySecurity) {
            if (directorySecurity == null)
                return null;

            return new DirectorySecurityAdapter(directorySecurity);
        }

        [ContractAnnotation("directorySecurity:null=>null")]
        public static DirectorySecurity Unwrap(IDirectorySecurity directorySecurity) {
            if (directorySecurity == null)
                return null;

            var adapter = directorySecurity as DirectorySecurityAdapter;
            if (adapter == null)
                throw new InvalidOperationException("Adapter can only accept DirectorySecurityAdaper (provided " + directorySecurity.GetType().Name + ").");

            return adapter.Security;
        }

        [ContractAnnotation("fileSecurity:null=>null")]
        public static IFileSecurity Adapt(FileSecurity fileSecurity) {
            if (fileSecurity == null)
                return null;

            return new FileSecurityAdapter(fileSecurity);
        }

        [ContractAnnotation("fileSecurity:null=>null")]
        public static FileSecurity Unwrap(IFileSecurity fileSecurity) {
            if (fileSecurity == null)
                return null;

            var adapter = fileSecurity as FileSecurityAdapter;
            if (adapter == null)
                throw new InvalidOperationException("Adapter can only accept DirectorySecurityAdaper (provided " + fileSecurity.GetType().Name + ").");

            return adapter.Security;
        }

        public static IDirectory GetDirectory([NotNull] string path, GetOption option = GetOption.Existing) {
            var directory = new DirectoryInfo(path);
            if (option == GetOption.Existing && !directory.Exists)
                return null;

            return AdapterHelper.Adapt(directory);
        }

        public static IFile GetFile([NotNull] string path, GetOption option = GetOption.Existing) {
            var file = new FileInfo(path);
            if (option == GetOption.Existing && !file.Exists)
                return null;

            return AdapterHelper.Adapt(file);
        }

        public static IFileSystemInfo GetFileSystemInfo([NotNull] string path) {
            var file = new FileInfo(path);
            if (file.Exists)
                return AdapterHelper.Adapt(file);

            var directory = new DirectoryInfo(path);
            if (directory.Exists)
                return AdapterHelper.Adapt(directory);

            return null;
        }
    }
}
