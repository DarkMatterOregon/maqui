using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Oqtane.Repository;
using DarkMatter.Module.Maqui.Repository;

namespace DarkMatter.Module.Maqui.Manager
{
    public class MaquiManager : MigratableModuleBase, IInstallable, IPortable
    {
        private readonly IMaquiRepository _MaquiRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public MaquiManager(IMaquiRepository MaquiRepository, IDBContextDependencies DBContextDependencies)
        {
            _MaquiRepository = MaquiRepository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new MaquiContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new MaquiContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Models.Maqui> Maquis = _MaquiRepository.GetMaquis(module.ModuleId).ToList();
            if (Maquis != null)
            {
                content = JsonSerializer.Serialize(Maquis);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Models.Maqui> Maquis = null;
            if (!string.IsNullOrEmpty(content))
            {
                Maquis = JsonSerializer.Deserialize<List<Models.Maqui>>(content);
            }
            if (Maquis != null)
            {
                foreach(var Maqui in Maquis)
                {
                    _MaquiRepository.AddMaqui(new Models.Maqui { ModuleId = module.ModuleId, Name = Maqui.Name });
                }
            }
        }
    }
}
