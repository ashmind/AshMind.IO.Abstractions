using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using AshMind.IO.Abstractions.Security;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Adapters {
    public class FileSecurityAdapter : FileSystemSecurityAdapter, IFileSecurity {
        [NotNull] private readonly FileSecurity _fileSecurity;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSecurityAdapter"/> class.
        /// </summary>
        public FileSecurityAdapter([NotNull] FileSecurity fileSecurity) : base(fileSecurity) {
            if (fileSecurity == null)
                throw new ArgumentNullException("fileSecurity");

            _fileSecurity = fileSecurity;
        }

        public new FileSecurity Security {
            get { return _fileSecurity; }
        }
    }
}
