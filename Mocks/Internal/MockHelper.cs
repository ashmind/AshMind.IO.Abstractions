using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Mocks.Internal {
    internal static class MockHelper {
        public static void Choose([NotNull] FileSystemInfoMock fileSystemInfo, [NotNull] Action<FileMock> handleFile, [NotNull] Action<DirectoryMock> handleDirectory) {
            var file = fileSystemInfo as FileMock;
            if (file != null) {
                handleFile(file);
                return;
            }

            var directory = fileSystemInfo as DirectoryMock;
            if (directory != null) {
                handleDirectory(directory);
                return;
            }

            throw new NotSupportedException("Item should be either FileMock or a DirectoryMock (received " + fileSystemInfo.GetType() + ").");
        }
    }
}
