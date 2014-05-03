using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static IDirectory GetDirectory([NotNull] string path, GetOption option = GetOption.Always) {
            var directory = new DirectoryInfo(path);
            if (option == GetOption.OnlyIfExists && !directory.Exists)
                return null;

            return AdapterHelper.Adapt(directory);
        }

        public static IFile GetFile([NotNull] string path, GetOption option = GetOption.Always) {
            var file = new FileInfo(path);
            if (option == GetOption.OnlyIfExists && !file.Exists)
                return null;

            return AdapterHelper.Adapt(file);
        }
    }
}
