// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using AshMind.IO.Abstractions.Properties;

[assembly: AssemblyTitle("AshMind.IO.Abstractions")]
[assembly: AssemblyCompany("Andrey Shchekin")]
[assembly: AssemblyProduct("AshMind.IO.Abstractions")]
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

[assembly: InternalsVisibleTo("AshMind.IO.Abstractions.Mocks")]

namespace AshMind.IO.Abstractions.Properties {
    internal static class AssemblyInfo {
        public const string VersionString = "0.8.1.0";
        public const string VersionStringFull = VersionString + "-pre";
    }
}