using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using DarkMatter.Module.Maqui.Models;

namespace DarkMatter.Module.Maqui.Services
{
    public class MaquiService : ServiceBase, IMaquiService, IService
    {
        public MaquiService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Maqui");

        public async Task<List<Models.Maqui>> GetMaquisAsync(int ModuleId)
        {
            List<Models.Maqui> Maquis = await GetJsonAsync<List<Models.Maqui>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId), Enumerable.Empty<Models.Maqui>().ToList());
            return Maquis.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.Maqui> GetMaquiAsync(int MaquiId, int ModuleId)
        {
            return await GetJsonAsync<Models.Maqui>(CreateAuthorizationPolicyUrl($"{Apiurl}/{MaquiId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.Maqui> AddMaquiAsync(Models.Maqui Maqui)
        {
            return await PostJsonAsync<Models.Maqui>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, Maqui.ModuleId), Maqui);
        }

        public async Task<Models.Maqui> UpdateMaquiAsync(Models.Maqui Maqui)
        {
            return await PutJsonAsync<Models.Maqui>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Maqui.MaquiId}", EntityNames.Module, Maqui.ModuleId), Maqui);
        }

        public async Task DeleteMaquiAsync(int MaquiId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{MaquiId}", EntityNames.Module, ModuleId));
        }
    }
}
