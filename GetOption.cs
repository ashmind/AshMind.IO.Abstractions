namespace AshMind.IO.Abstractions {
    public enum GetOption {
        /// <summary>
        /// Return an <see cref="IFileSystemInfo"/> whether the path exists or not.
        /// <see cref="IFileSystemInfo.Exists" /> can be used to determine existence.
        /// </summary>
        Always,

        /// <summary>
        /// Return an <see cref="IFileSystemInfo"/> if path exists, and <c>null</c> otherwise.
        /// </summary>
        OnlyIfExists
    }
}