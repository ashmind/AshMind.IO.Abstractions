using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using AshMind.IO.Abstractions.Security;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Mocks {
    [PublicAPI]
    public class FileMock : FileSystemInfoMock, IFile {
        [NotNull] private MemoryStream _data = new MemoryStream();
        [CanBeNull] private string _fullName;

        public FileMock([NotNull] string name, [CanBeNull] string contents, [CanBeNull] Encoding encoding = null) : this(name) {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            WriteAllText(contents, encoding ?? Encoding.UTF8);
        }

        public FileMock([NotNull] string name, [NotNull] byte[] contents) : this(name) {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            WriteAllBytes(contents);
        }
        
        private FileMock([NotNull] string name) {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Name = name;
            Extension = Path.GetExtension(this.Name);
            Exists = true;
            FileSystem = new FileSystemMock();
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        public string DirectoryName {
            get { return Directory != null ? Directory.FullName : null; }
        }

        public IDirectory Directory { get; set; }
        public override string FullName {
            get {
                if (_fullName != null)
                    return _fullName;

                if (this.DirectoryName == null)
                    return this.Name;

                return Path.Combine(this.DirectoryName, this.Name);
            }
            set { _fullName = value; }
        }

        public long Length {
            get { return _data.Length; }
        }

        public IFileSecurity GetAccessControl() {
            throw new NotImplementedException();
        }

        public IFileSecurity GetAccessControl(AccessControlSections includeSections) {
            throw new NotImplementedException();
        }

        public void SetAccessControl(IFileSecurity fileSecurity) {
            throw new NotImplementedException();
        }

        public StreamReader OpenText() {
            throw new NotImplementedException();
        }

        public StreamWriter CreateText() {
            throw new NotImplementedException();
        }

        public StreamWriter AppendText() {
            throw new NotImplementedException();
        }

        public IFile CopyTo(string destFileName) {
            throw new NotImplementedException();
        }

        public IFile CopyTo(string destFileName, bool overwrite) {
            EnsureExists();

            var file = FileSystem.GetFile(destFileName);
            if (file == null) {
                file = new FileMock(Path.GetFileName(destFileName), _data.ToArray()) {
                    FullName = destFileName
                };
                FileSystem.AddFile(file);
            }
            else if (overwrite) {
                file.WriteAllBytes(this.ReadAllBytes());
            }
            else {
                throw new IOException(string.Format("Cannot copy '{1}' to '{0}': file already exists.", destFileName, this.FullName));
            }

            return file;
        }

        public Stream Create() {
            throw new NotImplementedException();
        }

        public void Decrypt() {
            throw new NotImplementedException();
        }

        public void Encrypt() {
            throw new NotImplementedException();
        }

        public Stream Open(FileMode mode) {
            return this.Open(mode, FileAccess.ReadWrite, FileShare.None);
        }

        public Stream Open(FileMode mode, FileAccess access) {
            return this.Open(mode, access, FileShare.None);
        }

        public Stream Open(FileMode mode, FileAccess access, FileShare share) {
            if (!Exists && (mode == FileMode.Open || mode == FileMode.Truncate))
                throw new FileNotFoundException();

            _data.Seek(0, SeekOrigin.Begin);
            return _data;
        }
        

        public Stream OpenRead() {
            throw new NotImplementedException();
        }

        public Stream OpenWrite() {
            return this.Open(FileMode.OpenOrCreate);
        }

        public void MoveTo(string destFileName) {
            throw new NotImplementedException();
        }

        public IFile Replace(string destinationFileName, string destinationBackupFileName) {
            throw new NotImplementedException();
        }

        public IFile Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors) {
            throw new NotImplementedException();
        }

        public bool IsReadOnly { get; set; }

        public string ReadAllText() {
            EnsureExists();
            // using StreamReader here to piggyback on its encoding detection
            return new StreamReader(_data).ReadToEnd();
        }

        public string ReadAllText(Encoding encoding) {
            EnsureExists();
            return encoding.GetString(ReadAllBytes());
        }

        public string[] ReadAllLines() {
            EnsureExists();
            return ReadAllText().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public string[] ReadAllLines(Encoding encoding) {
            EnsureExists();
            return ReadAllText(encoding).Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public byte[] ReadAllBytes() {
            EnsureExists();
            return _data.ToArray();
        }

        public void WriteAllText(string contents) {
            WriteAllText(contents, Encoding.UTF8);
        }

        public void WriteAllText(string contents, Encoding encoding) {
            if (contents == null)
                return;

            WriteAllBytes(encoding.GetBytes(contents));
        }

        public void WriteAllLines(string[] contents) {
            WriteAllLines(contents, Encoding.UTF8);
        }

        public void WriteAllLines(string[] contents, Encoding encoding) {
            WriteAllText(string.Join(Environment.NewLine, contents), encoding);
        }

        public void WriteAllLines(IEnumerable<string> contents) {
            WriteAllLines(contents, Encoding.UTF8);
        }

        public void WriteAllLines(IEnumerable<string> contents, Encoding encoding) {
            WriteAllText(string.Join(Environment.NewLine, contents), encoding);
        }

        public void WriteAllBytes(byte[] bytes) {
            _data = new MemoryStream(bytes);
        }

        public void AppendAllText(string contents) {
            throw new NotImplementedException();
        }

        public void AppendAllText(string contents, Encoding encoding) {
            throw new NotImplementedException();
        }

        public void AppendAllLines(string[] contents) {
            throw new NotImplementedException();
        }

        public void AppendAllLines(string[] contents, Encoding encoding) {
            throw new NotImplementedException();
        }

        public void AppendAllLines(IEnumerable<string> contents) {
            throw new NotImplementedException();
        }

        public void AppendAllLines(IEnumerable<string> contents, Encoding encoding) {
            throw new NotImplementedException();
        }
    }
}
