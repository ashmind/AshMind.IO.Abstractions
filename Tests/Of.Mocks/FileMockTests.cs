using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Extensions;
using AshMind.IO.Abstractions.Mocks;
using AshMind.IO.Abstractions.Tests.Internal;

namespace AshMind.IO.Abstractions.Tests.Of.Mocks {
    public class FileMockTests {
        [Theory]
        [ReflectionData(typeof(FileMock), MemberTypes.Method, BindingFlags.Instance | BindingFlags.Public, NamePattern = "ReadAll.*")]
        public void ReadAll_Fails_IfExistsIsFalse(MethodInfo method) {
            var mock = new FileMock("test", "") { Exists = false };
            
            var exception = Assert.Throws<TargetInvocationException>(() => method.Invoke(mock, new object[method.GetParameters().Length]));
            Assert.IsType<FileNotFoundException>(exception.InnerException);
        }

        [Fact]
        public void CopyTo_OverwritesTargetFileContents_IfTargetFileExistsAndOverwriteIsTrue() {
            var fileSystem = new FileSystemMock();
            var source = new FileMock("test1", "Source") { FileSystem = fileSystem };
            var target = new FileMock("test2", "Target") { FileSystem = fileSystem };

            source.CopyTo(target.FullName, true);

            Assert.Equal(target.ReadAllText(), source.ReadAllText());
        }
    }
}
