using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using AshMind.IO.Abstractions.Security;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Adapters {
    /// <summary>
    /// Wraps <see cref="FileInfo" /> and adapts it to the <see cref="IFile" /> interface.
    /// </summary>
    public class FileInfoAdapter : FileSystemInfoAdapter, IFile {
        [NotNull] private readonly FileInfo _fileInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileInfoAdapter"/> class.
        /// </summary>
        public FileInfoAdapter([NotNull] FileInfo fileInfo) : base(fileInfo) {
            _fileInfo = fileInfo;
        }
        
        public virtual IFileSecurity GetAccessControl() {
            return AdapterHelper.Adapt(_fileInfo.GetAccessControl());
        }

        public virtual IFileSecurity GetAccessControl(AccessControlSections includeSections) {
            return AdapterHelper.Adapt(_fileInfo.GetAccessControl(includeSections));
        }

        public virtual void SetAccessControl(IFileSecurity fileSecurity) {
            _fileInfo.SetAccessControl(AdapterHelper.Unwrap(fileSecurity));
        }

        public virtual StreamReader OpenText() {
            return _fileInfo.OpenText();
        }

        public virtual StreamWriter CreateText() {
            return _fileInfo.CreateText();
        }

        public virtual StreamWriter AppendText() {
            return _fileInfo.AppendText();
        }

        public virtual IFile CopyTo(string destFileName) {
            // ReSharper disable once AssignNullToNotNullAttribute
            return AdapterHelper.Adapt(_fileInfo.CopyTo(destFileName));
        }

        public virtual IFile CopyTo(string destFileName, bool overwrite) {
            // ReSharper disable once AssignNullToNotNullAttribute
            return AdapterHelper.Adapt(_fileInfo.CopyTo(destFileName, overwrite));
        }

        public virtual Stream Create() {
            return _fileInfo.Create();
        }
        
        public virtual void Decrypt() {
            _fileInfo.Decrypt();
        }

        public virtual void Encrypt() {
            _fileInfo.Encrypt();
        }

        public virtual Stream Open(FileMode mode) {
            return _fileInfo.Open(mode);
        }

        public virtual Stream Open(FileMode mode, FileAccess access) {
            return _fileInfo.Open(mode, access);
        }

        public virtual Stream Open(FileMode mode, FileAccess access, FileShare share) {
            return _fileInfo.Open(mode, access, share);
        }

        public virtual Stream OpenRead() {
            return _fileInfo.OpenRead();
        }

        public virtual Stream OpenWrite() {
            return _fileInfo.OpenWrite();
        }

        public virtual void MoveTo(string destFileName) {
            _fileInfo.MoveTo(destFileName);
        }

        public virtual IFile Replace(string destinationFileName, string destinationBackupFileName) {
            // ReSharper disable once AssignNullToNotNullAttribute
            return AdapterHelper.Adapt(_fileInfo.Replace(destinationFileName, destinationBackupFileName));
        }

        public virtual IFile Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors) {
            // ReSharper disable once AssignNullToNotNullAttribute
            return AdapterHelper.Adapt(_fileInfo.Replace(destinationFileName, destinationBackupFileName, ignoreMetadataErrors));
        }
        
        public virtual long Length {
            get { return _fileInfo.Length; }
        }

        public virtual string DirectoryName {
            get { return _fileInfo.DirectoryName; }
        }

        public virtual IDirectory Directory {
            get { return AdapterHelper.Adapt(_fileInfo.Directory); }
        }

        public virtual bool IsReadOnly {
            get { return _fileInfo.IsReadOnly; }
            set { _fileInfo.IsReadOnly = value; }
        }
        
        public virtual string ReadAllText() {
            return File.ReadAllText(_fileInfo.FullName);
        }

        public virtual string ReadAllText(Encoding encoding) {
            return File.ReadAllText(_fileInfo.FullName, encoding);
        }

        public virtual string[] ReadAllLines() {
            return File.ReadAllLines(_fileInfo.FullName);
        }

        public virtual string[] ReadAllLines(Encoding encoding) {
            return File.ReadAllLines(_fileInfo.FullName, encoding);
        }

        public virtual byte[] ReadAllBytes() {
            return File.ReadAllBytes(_fileInfo.FullName);
        }

        public virtual void WriteAllText(string contents) {
            File.WriteAllText(_fileInfo.FullName, contents);
        }

        public virtual void WriteAllText(string contents, Encoding encoding) {
            File.WriteAllText(_fileInfo.FullName, contents, encoding);
        }

        public virtual void WriteAllLines(string[] contents) {
            File.WriteAllLines(_fileInfo.FullName, contents);
        }

        public virtual void WriteAllLines(string[] contents, Encoding encoding) {
            File.WriteAllLines(_fileInfo.FullName, contents, encoding);
        }

        public virtual void WriteAllLines(IEnumerable<string> contents) {
            File.WriteAllLines(_fileInfo.FullName, contents);
        }

        public virtual void WriteAllLines(IEnumerable<string> contents, Encoding encoding) {
            File.WriteAllLines(_fileInfo.FullName, contents, encoding);
        }

        public virtual void WriteAllBytes(byte[] bytes) {
            File.WriteAllBytes(_fileInfo.FullName, bytes);
        }

        public virtual void AppendAllText(string contents) {
            File.AppendAllText(_fileInfo.FullName, contents);
        }

        public virtual void AppendAllText(string contents, Encoding encoding) {
            File.AppendAllText(_fileInfo.FullName, contents, encoding);
        }

        public virtual void AppendAllLines(string[] contents) {
            File.AppendAllLines(_fileInfo.FullName, contents);
        }

        public virtual void AppendAllLines(string[] contents, Encoding encoding) {
            File.AppendAllLines(_fileInfo.FullName, contents, encoding);
        }

        public virtual void AppendAllLines(IEnumerable<string> contents) {
            File.AppendAllLines(_fileInfo.FullName, contents);
        }

        public virtual void AppendAllLines(IEnumerable<string> contents, Encoding encoding) {
            File.AppendAllLines(_fileInfo.FullName, contents, encoding);
        }
    }
}
