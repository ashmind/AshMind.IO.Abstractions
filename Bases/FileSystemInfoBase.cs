using System;
using System.IO;

namespace AshMind.IO.Abstractions.Bases {
    public abstract class FileSystemInfoBase : IFileSystemInfo {
        public virtual string Extension {
            get { throw new NotImplementedException(); }
        }

        public virtual string Name {
            get { throw new NotImplementedException(); }
        }

        public virtual string FullName {
            get { throw new NotImplementedException(); }
        }

        public virtual bool Exists {
            get { throw new NotImplementedException(); }
        }

        public virtual DateTime CreationTime {
            get { return CreationTimeUtc.ToLocalTime(); }
            set { CreationTimeUtc = value.ToUniversalTime(); }
        }

        public virtual DateTime CreationTimeUtc {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public virtual DateTime LastAccessTime {
            get { return LastAccessTimeUtc.ToLocalTime(); }
            set { LastAccessTimeUtc = value.ToUniversalTime(); }
        }

        public virtual DateTime LastAccessTimeUtc {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public virtual DateTime LastWriteTime {
            get { return LastWriteTimeUtc.ToLocalTime(); }
            set { LastWriteTimeUtc = value.ToUniversalTime(); }
        }
        
        public virtual DateTime LastWriteTimeUtc {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public virtual FileAttributes Attributes {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public virtual void Delete() {
            throw new NotImplementedException();
        }

        public virtual void Refresh() {
            throw new NotImplementedException();
        }
    }
}