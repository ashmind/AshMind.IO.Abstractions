using System;
using System.IO;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Mocks {
    public class FileSystemInfoMock : IFileSystemInfo {
        [CanBeNull] private string _fullName;
        [CanBeNull] private FileSystemMock _fileSystem;

        public FileSystemInfoMock([NotNull] string name = "") {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Name = name;
            Extension = Path.GetExtension(this.Name);
            Exists = true;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }
        
        public virtual void Delete() {
            Exists = false;
        }

        public virtual void Refresh() {
        }

        protected void EnsureExists() {
            if (!this.Exists)
                throw new FileNotFoundException("'" + this.FullName + "' does not exist.");
        }

        public virtual string Extension { get; set; }
        public virtual string FullName {
            get {
                if (_fullName != null)
                    return _fullName;
                
                return this.Name;
            }
            set { _fullName = value; }
        }

        public virtual string Name { get; set; }
        public virtual bool Exists { get; set; }

        public virtual DateTime CreationTimeUtc { get; set; }
        public virtual DateTime LastAccessTimeUtc { get; set; }
        public virtual DateTime LastWriteTimeUtc { get; set; }
        public virtual FileAttributes Attributes { get; set; }

        public virtual DateTime CreationTime {
            get { return CreationTimeUtc.ToLocalTime(); }
            set { CreationTimeUtc = value.ToUniversalTime(); }
        }

        public virtual DateTime LastAccessTime {
            get { return LastAccessTimeUtc.ToLocalTime(); }
            set { LastAccessTimeUtc = value.ToUniversalTime(); }
        }

        public virtual DateTime LastWriteTime {
            get { return LastWriteTimeUtc.ToLocalTime(); }
            set { LastWriteTimeUtc = value.ToUniversalTime(); }
        }

        /// <summary>
        /// This is required for some operations, such as FileMock.CopyTo.
        /// </summary>
        [CanBeNull]
        public virtual FileSystemMock FileSystem {
            get { return _fileSystem; }
            set { _fileSystem = value; }
        }
    }
}