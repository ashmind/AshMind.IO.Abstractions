using System;
using System.Collections.Generic;
using System.IO;
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

        public virtual IFile[] GetFiles(string searchPattern) {
            throw new NotImplementedException();
        }

        public virtual IFile[] GetFiles(string searchPattern, SearchOption searchOption) {
            throw new NotImplementedException();
        }

        public virtual IFile[] GetFiles() {
            throw new NotImplementedException();
        }

        public virtual IDirectory[] GetDirectories() {
            throw new NotImplementedException();
        }

        public virtual IFileSystemInfo[] GetFileSystemInfos(string searchPattern) {
            throw new NotImplementedException();
        }

        public virtual IFileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption) {
            throw new NotImplementedException();
        }

        public virtual IFileSystemInfo[] GetFileSystemInfos() {
            throw new NotImplementedException();
        }

        public virtual IDirectory[] GetDirectories(string searchPattern) {
            throw new NotImplementedException();
        }

        public virtual IDirectory[] GetDirectories(string searchPattern, SearchOption searchOption) {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<IDirectory> EnumerateDirectories() {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<IDirectory> EnumerateDirectories(string searchPattern) {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<IDirectory> EnumerateDirectories(string searchPattern, SearchOption searchOption) {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<IFile> EnumerateFiles() {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<IFile> EnumerateFiles(string searchPattern) {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<IFile> EnumerateFiles(string searchPattern, SearchOption searchOption) {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos() {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern) {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption) {
            throw new NotImplementedException();
        }

        public virtual void MoveTo(string destDirName) {
            throw new NotImplementedException();
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
        
        public IDirectory GetDirectory(string name, GetOption option = GetOption.Always) {
            throw new NotImplementedException();
        }

        public IFile GetFile(string name, GetOption option = GetOption.Always) {
            throw new NotImplementedException();
        }
    }
}