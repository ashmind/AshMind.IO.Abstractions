using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AshMind.IO.Abstractions.Bases;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Mocks {
    [PublicAPI]
    public class FileMock : FileBase, IFile {
        [NotNull] private MemoryStream _data;
        [CanBeNull] private string _fullName;

        public FileMock([NotNull] string name, [CanBeNull] string contents, [CanBeNull] Encoding encoding = null) : this(name) {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            SetContents(contents, encoding);
        }

        public FileMock([NotNull] string name, [NotNull] byte[] contents) : this(name) {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            SetContents(contents);
        }

        private FileMock([NotNull] string name) {
            Name = name;
            Extension = Path.GetExtension(this.Name);
            Exists = true;
        }

        public virtual void SetContents([CanBeNull] string contents, [CanBeNull] Encoding encoding = null) {
            encoding = encoding ?? Encoding.UTF8;
            contents = contents ?? "";
            SetContents(encoding.GetBytes(contents));
        }

        public virtual void SetContents([NotNull] byte[] contents) {
            _data = new MemoryStream(contents);
        }
        
        public override Stream Open(FileMode mode, FileAccess access, FileShare share) {
            if (!Exists)
                throw new FileNotFoundException();

            _data.Seek(0, SeekOrigin.Begin);
            return _data;
        }

        public override void Delete() {
            Exists = false;
        }
        
        public override void Refresh() {
        }

        public override string DirectoryName {
            get { return Directory != null ? Directory.FullName : null; }
        }

        public new IDirectory Directory { get; set; }
        public new string Extension { get; set; }
        public new string FullName {
            get {
                if (_fullName != null)
                    return _fullName;

                if (this.DirectoryName == null)
                    return this.Name;

                return Path.Combine(this.DirectoryName, this.Name);
            }
            set { _fullName = value; }
        }

        public new string Name { get; set; }
        public new bool Exists { get; set; }

        public override DateTime CreationTimeUtc { get; set; }
        public override DateTime LastAccessTimeUtc { get; set; }
        public override DateTime LastWriteTimeUtc { get; set; }
        public override FileAttributes Attributes { get; set; }

        public override long Length {
            get { return _data.Length; }
        }
    }
}
