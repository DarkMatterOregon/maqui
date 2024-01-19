using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace DarkMatter.Module.Maqui.Repository
{
    public class MaquiContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.Maqui> Maqui { get; set; }

        public MaquiContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
