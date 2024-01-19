using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using DarkMatter.Module.Maqui.Models;

namespace DarkMatter.Module.Maqui.Repository
{
    public class MaquiRepository : IMaquiRepository, ITransientService
    {
        private readonly MaquiContext _db;

        public MaquiRepository(MaquiContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.Maqui> GetMaquis(int ModuleId)
        {
            return _db.Maqui.Where(item => item.ModuleId == ModuleId);
        }

        public Models.Maqui GetMaqui(int MaquiId)
        {
            return GetMaqui(MaquiId, true);
        }

        public Models.Maqui GetMaqui(int MaquiId, bool tracking)
        {
            if (tracking)
            {
                return _db.Maqui.Find(MaquiId);
            }
            else
            {
                return _db.Maqui.AsNoTracking().FirstOrDefault(item => item.MaquiId == MaquiId);
            }
        }

        public Models.Maqui AddMaqui(Models.Maqui Maqui)
        {
            _db.Maqui.Add(Maqui);
            _db.SaveChanges();
            return Maqui;
        }

        public Models.Maqui UpdateMaqui(Models.Maqui Maqui)
        {
            _db.Entry(Maqui).State = EntityState.Modified;
            _db.SaveChanges();
            return Maqui;
        }

        public void DeleteMaqui(int MaquiId)
        {
            Models.Maqui Maqui = _db.Maqui.Find(MaquiId);
            _db.Maqui.Remove(Maqui);
            _db.SaveChanges();
        }
    }
}
