using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Extensions;
using AshMind.IO.Abstractions.Mocks;
using AshMind.IO.Abstractions.Tests.Internal;

namespace AshMind.IO.Abstractions.Tests.Of.Mocks {
    public class DirectoryMockTests {
        //[Theory]
        //[ReflectionData(typeof(DirectoryMock), MemberTypes.Method, BindingFlags.Instance | BindingFlags.Public, NamePattern = "Get.*")]
        //public void Get_Fails_IfExistsIsFalse(MethodInfo method) {
        //    var mock = new DirectoryMock("test") { Exists = false };
            
        //    var exception = Assert.Throws<TargetInvocationException>(() => method.Invoke(mock, new object[method.GetParameters().Length]));
        //    Assert.IsType<FileNotFoundException>(exception.InnerException);
        //}

        [Fact]
        public void GetFiles_ReturnsAllFiles() {
            var files = new[] { new FileMock("file1"), new FileMock("file2") };
            var mock = new DirectoryMock("test", files);
            Assert.Equal(files, mock.GetFiles());
        }
    }
}
