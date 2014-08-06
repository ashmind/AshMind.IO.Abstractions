using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using AshMind.IO.Abstractions.Security;

namespace AshMind.IO.Abstractions.Bases {
    public abstract class DirectoryBase : FileSystemInfoBase, IDirectory {
        public virtual IDirectory CreateSubdirectory(string path) {
            throw new NotImplementedException();
        }

        public virtual IDirectory CreateSubdirectory(string path, IDirectorySecurity directorySecurity) {
            throw new NotImplementedException();
        }

        public virtual void Create() {
            throw new NotImplementedException();
        }

        public virtual void Create(IDirectorySecurity directorySecurity) {
            throw new NotImplementedException();
        }

        public virtual IDirectorySecurity GetAccessControl() {
            throw new NotImplementedException();
        }

        public virtual IDirectorySecurity GetAccessControl(AccessControlSections includeSections) {
            throw new NotImplementedException();
        }

        public virtual void SetAccessControl(IDirectorySecurity directorySecurity) {
            throw new NotImplementedException();
        }

        public virtual IFile[] GetFiles() {
            return GetFiles("*", SearchOption.TopDirectoryOnly);
        }

        public virtual IFile[] GetFiles(string searchPattern) {
            return GetFiles(searchPattern, SearchOption.TopDirectoryOnly);
        }

        public virtual IFile[] GetFiles(string searchPattern, SearchOption searchOption) {
            return EnumerateFiles(searchPattern, searchOption).ToArray();
        }

        public virtual IDirectory[] GetDirectories() {
            return GetDirectories("*", SearchOption.TopDirectoryOnly);
        }

        public virtual IDirectory[] GetDirectories(string searchPattern) {
            return GetDirectories(searchPattern, SearchOption.TopDirectoryOnly);
        }

        public virtual IDirectory[] GetDirectories(string searchPattern, SearchOption searchOption) {
            return EnumerateDirectories(searchPattern, searchOption).ToArray();
        }
        
        public virtual IFileSystemInfo[] GetFileSystemInfos() {
            return GetFileSystemInfos("*");
        }

        public virtual IFileSystemInfo[] GetFileSystemInfos(string searchPattern) {
            return GetFileSystemInfos("*", SearchOption.TopDirectoryOnly);
        }

        public virtual IFileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption) {
            return EnumerateDirectories(searchPattern, searchOption).ToArray();
        }

        public virtual IEnumerable<IDirectory> EnumerateDirectories() {
            return EnumerateDirectories("*", SearchOption.TopDirectoryOnly);
        }

        public virtual IEnumerable<IDirectory> EnumerateDirectories(string searchPattern) {
            return EnumerateDirectories(searchPattern, SearchOption.TopDirectoryOnly);
        }

        public virtual IEnumerable<IDirectory> EnumerateDirectories(string searchPattern, SearchOption searchOption) {
            return EnumerateFileSystemInfos(searchPattern, searchOption).OfType<IDirectory>();
        }

        public virtual IEnumerable<IFile> EnumerateFiles() {
            return EnumerateFiles("*", SearchOption.TopDirectoryOnly);
        }

        public virtual IEnumerable<IFile> EnumerateFiles(string searchPattern) {
            return EnumerateFiles(searchPattern, SearchOption.TopDirectoryOnly);
        }

        public virtual IEnumerable<IFile> EnumerateFiles(string searchPattern, SearchOption searchOption) {
            return EnumerateFileSystemInfos(searchPattern, searchOption).OfType<IFile>();
        }

        public virtual IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos() {
            return EnumerateFileSystemInfos("*", SearchOption.TopDirectoryOnly);
        }

        public virtual IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern) {
            return EnumerateFileSystemInfos(searchPattern, SearchOption.TopDirectoryOnly);;
        }

        public virtual IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption) {
            throw new NotImplementedException();
        }

        public virtual void MoveTo(string destDirName) {
            throw new NotImplementedException();
        }

        public override void Delete() {
            Delete(false);
        }

        public virtual void Delete(bool recursive) {
            throw new NotImplementedException();
        }

        public virtual IDirectory Parent {
            get { throw new NotImplementedException(); }
        }

        public virtual IDirectory Root {
            get { throw new NotImplementedException(); }
        }
        
        public virtual IDirectory GetDirectory(string name, GetOption option = GetOption.Existing) {
            throw new NotImplementedException();
        }

        public virtual IFile GetFile(string name, GetOption option = GetOption.Existing) {
            throw new NotImplementedException();
        }

        public virtual IFileSystemInfo GetFileSystemInfo(string name) {
            throw new NotImplementedException();
        }
    }
}