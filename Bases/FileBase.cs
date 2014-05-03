using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text;
using AshMind.IO.Abstractions.Security;

namespace AshMind.IO.Abstractions.Bases {
    public abstract class FileBase : FileSystemInfoBase, IFile {
        public virtual IFileSecurity GetAccessControl() {
            throw new NotImplementedException();
        }

        public virtual IFileSecurity GetAccessControl(AccessControlSections includeSections) {
            throw new NotImplementedException();
        }

        public virtual void SetAccessControl(IFileSecurity fileSecurity) {
            throw new NotImplementedException();
        }

        public virtual StreamReader OpenText() {
            throw new NotImplementedException();
        }

        public virtual StreamWriter CreateText() {
            throw new NotImplementedException();
        }

        public virtual StreamWriter AppendText() {
            throw new NotImplementedException();
        }

        public virtual IFile CopyTo(string destFileName) {
            throw new NotImplementedException();
        }

        public virtual IFile CopyTo(string destFileName, bool overwrite) {
            throw new NotImplementedException();
        }

        public virtual Stream Create() {
            throw new NotImplementedException();
        }

        public virtual void Decrypt() {
            throw new NotImplementedException();
        }

        public virtual void Encrypt() {
            throw new NotImplementedException();
        }

        public virtual Stream Open(FileMode mode) {
            throw new NotImplementedException();
        }

        public virtual Stream Open(FileMode mode, FileAccess access) {
            throw new NotImplementedException();
        }

        public virtual Stream Open(FileMode mode, FileAccess access, FileShare share) {
            throw new NotImplementedException();
        }

        public virtual Stream OpenRead() {
            throw new NotImplementedException();
        }

        public virtual Stream OpenWrite() {
            throw new NotImplementedException();
        }

        public virtual void MoveTo(string destFileName) {
            throw new NotImplementedException();
        }

        public virtual IFile Replace(string destinationFileName, string destinationBackupFileName) {
            throw new NotImplementedException();
        }

        public virtual IFile Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors) {
            throw new NotImplementedException();
        }

        public virtual long Length {
            get { throw new NotImplementedException(); }
        }

        public virtual string DirectoryName {
            get { throw new NotImplementedException(); }
        }

        public virtual IDirectory Directory {
            get { throw new NotImplementedException(); }
        }

        public virtual bool IsReadOnly {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public virtual string ReadAllText() {
            throw new NotImplementedException();
        }

        public virtual string ReadAllText(Encoding encoding) {
            throw new NotImplementedException();
        }

        public virtual string[] ReadAllLines() {
            throw new NotImplementedException();
        }

        public virtual string[] ReadAllLines(Encoding encoding) {
            throw new NotImplementedException();
        }

        public virtual byte[] ReadAllBytes() {
            throw new NotImplementedException();
        }

        public virtual void WriteAllText(string content) {
            throw new NotImplementedException();
        }

        public virtual void WriteAllText(string contents, Encoding encoding) {
            throw new NotImplementedException();
        }

        public virtual void WriteAllLines(string[] contents) {
            throw new NotImplementedException();
        }

        public virtual void WriteAllLines(string[] contents, Encoding encoding) {
            throw new NotImplementedException();
        }

        public virtual void WriteAllLines(IEnumerable<string> contents) {
            throw new NotImplementedException();
        }

        public virtual void WriteAllLines(IEnumerable<string> contents, Encoding encoding) {
            throw new NotImplementedException();
        }

        public virtual void WriteAllBytes(byte[] bytes) {
            throw new NotImplementedException();
        }

        public virtual void AppendAllText(string contents) {
            throw new NotImplementedException();
        }

        public virtual void AppendAllText(string contents, Encoding encoding) {
            throw new NotImplementedException();
        }

        public virtual void AppendAllLines(string[] contents) {
            throw new NotImplementedException();
        }

        public virtual void AppendAllLines(string[] contents, Encoding encoding) {
            throw new NotImplementedException();
        }

        public virtual void AppendAllLines(IEnumerable<string> contents) {
            throw new NotImplementedException();
        }

        public virtual void AppendAllLines(IEnumerable<string> contents, Encoding encoding) {
            throw new NotImplementedException();
        }
    }
}