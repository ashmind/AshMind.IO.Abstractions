using System;
using System.IO;
using AshMind.IO.Abstractions.Bases;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Mocks {
    public class FileSystemInfoMock : FileSystemInfoBase, IFileSystemInfo {
        [CanBeNull] private string _fullName;
        
        public FileSystemInfoMock([NotNull] string name = "") {
            Name = name;
            Extension = Path.GetExtension(this.Name);
            Exists = true;
        }
        
        public override void Delete() {
            Exists = false;
        }
        
        public override void Refresh() {
        }

        public new string Extension { get; set; }
        public new string FullName {
            get {
                if (_fullName != null)
                    return _fullName;
                
                return this.Name;
            }
            set { _fullName = value; }
        }

        public new string Name { get; set; }
        public new bool Exists { get; set; }

        public override DateTime CreationTimeUtc { get; set; }
        public override DateTime LastAccessTimeUtc { get; set; }
        public override DateTime LastWriteTimeUtc { get; set; }
        public override FileAttributes Attributes { get; set; }
    }
}