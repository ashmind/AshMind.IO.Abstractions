using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Adapters {
    public class DirectoryInfoAdapter : FileSystemInfoAdapter, IDirectory {
        [NotNull] private readonly DirectoryInfo _directoryInfo;

        public DirectoryInfoAdapter([NotNull] DirectoryInfo directoryInfo) : base(directoryInfo) {
            _directoryInfo = directoryInfo;
        }
        
        public virtual IDirectory CreateSubdirectory(string path) {
            return new DirectoryInfoAdapter(_directoryInfo.CreateSubdirectory(path));
        }

        public virtual IDirectory CreateSubdirectory(string path, DirectorySecurity directorySecurity) {
            return new DirectoryInfoAdapter(_directoryInfo.CreateSubdirectory(path, directorySecurity));
        }

        public virtual void Create() {
            _directoryInfo.Create();
        }

        public virtual void Create(DirectorySecurity directorySecurity) {
            _directoryInfo.Create(directorySecurity);
        }

        public virtual DirectorySecurity GetAccessControl() {
            return _directoryInfo.GetAccessControl();
        }

        public virtual DirectorySecurity GetAccessControl(AccessControlSections includeSections) {
            return _directoryInfo.GetAccessControl(includeSections);
        }

        public virtual void SetAccessControl(DirectorySecurity directorySecurity) {
            _directoryInfo.SetAccessControl(directorySecurity);
        }

        public virtual IFile[] GetFiles(string searchPattern) {
            return Array.ConvertAll(_directoryInfo.GetFiles(searchPattern), AdapterHelper.Adapt);
        }

        public virtual IFile[] GetFiles(string searchPattern, SearchOption searchOption) {
            return Array.ConvertAll(_directoryInfo.GetFiles(searchPattern, searchOption), AdapterHelper.Adapt);
        }

        public virtual IFile[] GetFiles() {
            return Array.ConvertAll(_directoryInfo.GetFiles(), AdapterHelper.Adapt);
        }

        public virtual IDirectory[] GetDirectories() {
            return Array.ConvertAll(_directoryInfo.GetDirectories(), AdapterHelper.Adapt);
        }

        public virtual IFileSystemInfo[] GetFileSystemInfos(string searchPattern) {
            return Array.ConvertAll(_directoryInfo.GetFileSystemInfos(searchPattern), AdapterHelper.Adapt);
        }

        public virtual IFileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption) {
            return Array.ConvertAll(_directoryInfo.GetFileSystemInfos(searchPattern, searchOption), AdapterHelper.Adapt);
        }

        public virtual IFileSystemInfo[] GetFileSystemInfos() {
            return Array.ConvertAll(_directoryInfo.GetFileSystemInfos(), AdapterHelper.Adapt);
        }

        public virtual IDirectory[] GetDirectories(string searchPattern) {
            return Array.ConvertAll(_directoryInfo.GetDirectories(searchPattern), AdapterHelper.Adapt);
        }

        public virtual IDirectory[] GetDirectories(string searchPattern, SearchOption searchOption) {
            return Array.ConvertAll(_directoryInfo.GetDirectories(searchPattern, searchOption), AdapterHelper.Adapt);
        }

        public virtual IEnumerable<IDirectory> EnumerateDirectories() {
            return _directoryInfo.EnumerateDirectories().Select(AdapterHelper.Adapt);
        }

        public virtual IEnumerable<IDirectory> EnumerateDirectories(string searchPattern) {
            return _directoryInfo.EnumerateDirectories(searchPattern).Select(AdapterHelper.Adapt);
        }

        public virtual IEnumerable<IDirectory> EnumerateDirectories(string searchPattern, SearchOption searchOption) {
            return _directoryInfo.EnumerateDirectories(searchPattern, searchOption).Select(AdapterHelper.Adapt);
        }

        public virtual IEnumerable<IFile> EnumerateFiles() {
            return _directoryInfo.EnumerateFiles().Select(AdapterHelper.Adapt);
        }

        public virtual IEnumerable<IFile> EnumerateFiles(string searchPattern) {
            return _directoryInfo.EnumerateFiles(searchPattern).Select(AdapterHelper.Adapt);
        }

        public virtual IEnumerable<IFile> EnumerateFiles(string searchPattern, SearchOption searchOption) {
            return _directoryInfo.EnumerateFiles(searchPattern, searchOption).Select(AdapterHelper.Adapt);
        }

        public virtual IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos() {
            return _directoryInfo.EnumerateFileSystemInfos().Select(AdapterHelper.Adapt);
        }

        public virtual IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern) {
            return _directoryInfo.EnumerateFileSystemInfos(searchPattern).Select(AdapterHelper.Adapt);
        }

        public virtual IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption) {
            return _directoryInfo.EnumerateFileSystemInfos(searchPattern, searchOption).Select(AdapterHelper.Adapt);
        }

        public virtual void MoveTo(string destDirName) {
            _directoryInfo.MoveTo(destDirName);
        }
        
        public virtual void Delete(bool recursive) {
            _directoryInfo.Delete(recursive);
        }
        
        public virtual IDirectory Parent {
            get { return AdapterHelper.Adapt(_directoryInfo.Parent); }
        }

        public virtual IDirectory Root {
            get { return AdapterHelper.Adapt(_directoryInfo.Root); }
        }
        
        public virtual IDirectory GetDirectory(string name, GetOption option = GetOption.Always) {
            return AdapterHelper.GetDirectory(Path.Combine(_directoryInfo.FullName, name), option);
        }

        public virtual IFile GetFile(string name, GetOption option = GetOption.Always) {
            return AdapterHelper.GetFile(Path.Combine(_directoryInfo.FullName, name), option);
        }
    }
}