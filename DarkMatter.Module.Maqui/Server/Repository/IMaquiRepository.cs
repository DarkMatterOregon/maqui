using System.Collections.Generic;
using DarkMatter.Module.Maqui.Models;

namespace DarkMatter.Module.Maqui.Repository
{
    public interface IMaquiRepository
    {
        IEnumerable<Models.Maqui> GetMaquis(int ModuleId);
        Models.Maqui GetMaqui(int MaquiId);
        Models.Maqui GetMaqui(int MaquiId, bool tracking);
        Models.Maqui AddMaqui(Models.Maqui Maqui);
        Models.Maqui UpdateMaqui(Models.Maqui Maqui);
        void DeleteMaqui(int MaquiId);
    }
}
