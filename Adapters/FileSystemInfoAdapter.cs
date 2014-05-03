using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Adapters {
    /// <summary>
    /// Wraps <see cref="FileSystemInfo" /> and adapts it to the <see cref="IFileSystemInfo" /> interface.
    /// </summary>
    [PublicAPI]
    public class FileSystemInfoAdapter : IFileSystemInfo {
        [NotNull] private readonly FileSystemInfo _fileSystemInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemInfoAdapter"/> class.
        /// </summary>
        public FileSystemInfoAdapter([NotNull] FileSystemInfo fileSystemInfo) {
            if (fileSystemInfo == null)
                throw new ArgumentNullException("fileSystemInfo");

            _fileSystemInfo = fileSystemInfo;
        }

        public virtual void Delete() {
            _fileSystemInfo.Delete();
        }

        public virtual void Refresh() {
            _fileSystemInfo.Refresh();
        }

        public virtual string Extension {
            get { return _fileSystemInfo.Extension; }
        }

        public virtual string FullName {
            get { return _fileSystemInfo.FullName; }
        }

        public virtual string Name {
            get { return _fileSystemInfo.Name; }
        }

        public virtual bool Exists {
            get { return _fileSystemInfo.Exists; }
        }

        public virtual DateTime CreationTimeUtc {
            get { return _fileSystemInfo.CreationTimeUtc; }
            set { _fileSystemInfo.CreationTimeUtc = value; }
        }

        public virtual DateTime CreationTime {
            get { return _fileSystemInfo.CreationTime; }
            set { _fileSystemInfo.CreationTime = value; }
        }

        public virtual DateTime LastAccessTime {
            get { return _fileSystemInfo.LastAccessTime; }
            set { _fileSystemInfo.LastAccessTime = value; }
        }

        public virtual DateTime LastAccessTimeUtc {
            get { return _fileSystemInfo.LastAccessTimeUtc; }
            set { _fileSystemInfo.LastAccessTimeUtc = value; }
        }

        public virtual DateTime LastWriteTime {
            get { return _fileSystemInfo.LastWriteTime; }
            set { _fileSystemInfo.LastWriteTime = value; }
        }

        public virtual DateTime LastWriteTimeUtc {
            get { return _fileSystemInfo.LastWriteTimeUtc; }
            set { _fileSystemInfo.LastWriteTimeUtc = value; }
        }

        public virtual FileAttributes Attributes {
            get { return _fileSystemInfo.Attributes; }
            set { _fileSystemInfo.Attributes = value; }
        }
    }
}
