using System.Collections.Generic;
using System.Threading.Tasks;
using DarkMatter.Module.Maqui.Models;

namespace DarkMatter.Module.Maqui.Services
{
    public interface IMaquiService 
    {
        Task<List<Models.Maqui>> GetMaquisAsync(int ModuleId);

        Task<Models.Maqui> GetMaquiAsync(int MaquiId, int ModuleId);

        Task<Models.Maqui> AddMaquiAsync(Models.Maqui Maqui);

        Task<Models.Maqui> UpdateMaquiAsync(Models.Maqui Maqui);

        Task DeleteMaquiAsync(int MaquiId, int ModuleId);
    }
}
