using System;
using System.IO;

namespace AshMind.IO.Abstractions.Bases {
    public abstract class FileSystemInfoBase : IFileSystemInfo {
        public virtual void Delete() {
            throw new NotImplementedException();
        }

        public virtual void Refresh() {
            throw new NotImplementedException();
        }

        public virtual string Extension {
            get { throw new NotImplementedException(); }
        }

        public virtual string FullName {
            get { throw new NotImplementedException(); }
        }

        public virtual string Name {
            get { throw new NotImplementedException(); }
        }

        public virtual bool Exists {
            get { throw new NotImplementedException(); }
        }

        public virtual DateTime CreationTimeUtc {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public virtual DateTime CreationTime {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public virtual DateTime LastAccessTime {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public virtual DateTime LastAccessTimeUtc {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public virtual DateTime LastWriteTime {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public virtual DateTime LastWriteTimeUtc {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public virtual FileAttributes Attributes {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }
    }
}