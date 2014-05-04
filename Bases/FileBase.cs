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
            return CopyTo(destFileName, false);
        }

        public virtual IFile CopyTo(string destFileName, bool overwrite) {
            throw new NotImplementedException();
        }

        public virtual void Decrypt() {
            throw new NotImplementedException();
        }

        public virtual void Encrypt() {
            throw new NotImplementedException();
        }

        public virtual Stream Create() {
            return Open(FileMode.Create, FileAccess.ReadWrite, FileShare.None);
        }

        public virtual Stream Open(FileMode mode) {
            return Open(mode, FileAccess.ReadWrite, FileShare.None);
        }

        public virtual Stream Open(FileMode mode, FileAccess access) {
            return Open(mode, access, FileShare.None);
        }

        public virtual Stream Open(FileMode mode, FileAccess access, FileShare share) {
            throw new NotImplementedException();
        }

        public virtual Stream OpenRead() {
            return Open(FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        public virtual Stream OpenWrite() {
            return Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
        }

        public virtual void MoveTo(string destFileName) {
            throw new NotImplementedException();
        }

        public virtual IFile Replace(string destinationFileName, string destinationBackupFileName) {
            return Replace(destinationFileName, destinationBackupFileName, false);
        }

        public virtual IFile Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors) {
            throw new NotImplementedException();
        }

        public virtual long Length {
            get { throw new NotImplementedException(); }
        }

        public virtual string DirectoryName {
            get {
                if (Directory == null)
                    return null;

                return Directory.FullName;
            }
        }

        public virtual IDirectory Directory {
            get { throw new NotImplementedException(); }
        }

        public virtual bool IsReadOnly {
            get { return (Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly; }
            set { Attributes = (value ? Attributes | FileAttributes.ReadOnly : Attributes & ~FileAttributes.ReadOnly); }
        }

        public virtual string ReadAllText() {
            return ReadAllText(Encoding.UTF8);
        }

        public virtual string ReadAllText(Encoding encoding) {
            using (var stream = OpenRead())
            using (var reader = new StreamReader(stream, encoding)) {
                return reader.ReadToEnd();
            }
        }

        public virtual string[] ReadAllLines() {
            return ReadAllLines(Encoding.UTF8);
        }

        public virtual string[] ReadAllLines(Encoding encoding) {
            using (var stream = OpenRead())
            using (var reader = new StreamReader(stream, encoding)) {
                var lines = new List<string>();
                var line = reader.ReadLine();
                while (line != null) {
                    lines.Add(line);
                    line = reader.ReadLine();
                }
                return lines.ToArray();
            }
        }

        public virtual byte[] ReadAllBytes() {
            using (var stream = OpenRead()) {
                var length = stream.Length;
                if (length > int.MaxValue)
                    throw new IOException("Cannot read stream longer than " + int.MaxValue + " bytes.");

                var buffer = new byte[length];
                stream.Read(buffer, 0, (int)length);
                return buffer;
            }
        }

        public virtual void WriteAllText(string contents) {
            WriteAllText(contents, Encoding.UTF8);
        }

        public virtual void WriteAllText(string contents, Encoding encoding) {
            using (var stream = OpenWrite())
            using (var writer = new StreamWriter(stream, encoding)) {
                writer.Write(contents);
            }
        }

        public virtual void WriteAllLines(string[] contents) {
            WriteAllLines((IEnumerable<string>)contents, Encoding.UTF8);
        }

        public virtual void WriteAllLines(string[] contents, Encoding encoding) {
            WriteAllLines((IEnumerable<string>)contents, Encoding.UTF8);
        }

        public virtual void WriteAllLines(IEnumerable<string> contents) {
            WriteAllLines(contents, Encoding.UTF8);
        }

        public virtual void WriteAllLines(IEnumerable<string> contents, Encoding encoding) {
            using (var stream = OpenWrite())
            using (var writer = new StreamWriter(stream, encoding)) {
                foreach (var line in contents) {
                    writer.Write(line);
                }
            }
        }

        public virtual void WriteAllBytes(byte[] bytes) {
            using (var stream = OpenWrite()) {
                stream.Write(bytes, 0, bytes.Length);
            }
        }

        public virtual void AppendAllText(string contents) {
            AppendAllText(contents, Encoding.UTF8);
        }

        public virtual void AppendAllText(string contents, Encoding encoding) {
            using (var stream = Open(FileMode.Append, FileAccess.Write, FileShare.None))
            using (var writer = new StreamWriter(stream, encoding)) {
                writer.Write(contents);
            }
        }

        public virtual void AppendAllLines(string[] contents) {
            AppendAllLines((IEnumerable<string>)contents, Encoding.UTF8);
        }

        public virtual void AppendAllLines(string[] contents, Encoding encoding) {
            AppendAllLines((IEnumerable<string>)contents, Encoding.UTF8);
        }

        public virtual void AppendAllLines(IEnumerable<string> contents) {
            AppendAllLines(contents, Encoding.UTF8);
        }

        public virtual void AppendAllLines(IEnumerable<string> contents, Encoding encoding) {
            using (var stream = Open(FileMode.Append, FileAccess.Write, FileShare.None))
            using (var writer = new StreamWriter(stream, encoding)) {
                foreach (var line in contents) {
                    writer.Write(line);
                }
            }
        }
    }
}