using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Xunit.Extensions;

namespace AshMind.IO.Abstractions.Tests.Internal {
    public class ReflectionDataAttribute : DataAttribute {
        private readonly Type _targetType;
        private readonly MemberTypes _memberTypes;
        private readonly BindingFlags _bindingFlags;

        public ReflectionDataAttribute(Type targetType, MemberTypes memberTypes, BindingFlags bindingFlags = BindingFlags.Default) {
            _targetType = targetType;
            _memberTypes = memberTypes;
            _bindingFlags = bindingFlags;
            NamePattern = "";
        }

        public string NamePattern { get; set; }

        public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest, Type[] parameterTypes) {
            var members = _targetType.FindMembers(_memberTypes, _bindingFlags, (m, _) => Regex.IsMatch(m.Name, NamePattern), null);
            return members.Select(m => new object[] { m });
        }
    }
}
