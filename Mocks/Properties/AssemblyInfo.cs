using System.Reflection;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
using AshMind.IO.Abstractions.Mocks.Properties;

[assembly: AssemblyTitle("AshMind.IO.Abstractions.Mocks")]
[assembly: AssemblyCompany("Andrey Shchekin")]
[assembly: AssemblyProduct("AshMind.IO.Abstractions.Mocks")]
[assembly: AssemblyCopyright("Copyright © Andrey Shchekin 2013–2014")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(AssemblyInfo.VersionString)]
[assembly: AssemblyFileVersion(AssemblyInfo.VersionString)]
[assembly: AssemblyInformationalVersion(AssemblyInfo.VersionStringFull)]

namespace AshMind.IO.Abstractions.Mocks.Properties {
    internal static class AssemblyInfo {
        public const string VersionString = Abstractions.Properties.AssemblyInfo.VersionString;
        public const string VersionStringFull = Abstractions.Properties.AssemblyInfo.VersionString + "-m1";
    }
}