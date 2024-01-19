using Oqtane.Models;
using Oqtane.Modules;

namespace DarkMatter.Module.Maqui
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Maqui",
            Description = "Sample Modules for the Maqui Theme",
            Version = "1.0.0",
            ServerManagerType = "DarkMatter.Module.Maqui.Manager.MaquiManager, DarkMatter.Module.Maqui.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "DarkMatter.Module.Maqui.Shared.Oqtane",
            PackageName = "DarkMatter.Module.Maqui" 
        };
    }
}
