using SolutionNamePlaceholder.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SolutionNamePlaceholder.Application.Services.Versao
{
    public sealed class VersionService : IVersionService
    {
        public VersaoDTO FullVersion { get; }

        public string ApiVersion { get; }

        public int Major { get; }

        public int Minor { get; }

        public int Patch { get; }

        public VersionService()
        {
            var assembly = Assembly.GetEntryAssembly()!;
            var versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!;
            var versionParts = versionAttribute.InformationalVersion.Split('+', '-');
            var versionString = versionParts[0];

            var parsedVersion = Version.Parse(versionString);

            Major = parsedVersion.Major;
            Minor = parsedVersion.Minor;
            Patch = parsedVersion.Build;
            FullVersion = new VersaoDTO() { Versao = parsedVersion.ToString(3) };
            ApiVersion = $"{Major}.{Minor}";
        }
    }
}
