using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using AshMind.IO.Abstractions.Security;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Adapters {
    public class DirectorySecurityAdapter : FileSystemSecurityAdapter, IDirectorySecurity {
        [NotNull] private readonly DirectorySecurity _directorySecurity;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectorySecurityAdapter"/> class.
        /// </summary>
        public DirectorySecurityAdapter([NotNull] DirectorySecurity directorySecurity) : base(directorySecurity) {
            if (directorySecurity == null)
                throw new ArgumentNullException("directorySecurity");

            _directorySecurity = directorySecurity;
        }

        public new DirectorySecurity Security {
            get { return _directorySecurity; }
        }
    }
}
