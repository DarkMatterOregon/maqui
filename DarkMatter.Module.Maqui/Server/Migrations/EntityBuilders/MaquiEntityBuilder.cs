using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace DarkMatter.Module.Maqui.Migrations.EntityBuilders
{
    public class MaquiEntityBuilder : AuditableBaseEntityBuilder<MaquiEntityBuilder>
    {
        private const string _entityTableName = "DarkMatterMaqui";
        private readonly PrimaryKey<MaquiEntityBuilder> _primaryKey = new("PK_DarkMatterMaqui", x => x.MaquiId);
        private readonly ForeignKey<MaquiEntityBuilder> _moduleForeignKey = new("FK_DarkMatterMaqui_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public MaquiEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override MaquiEntityBuilder BuildTable(ColumnsBuilder table)
        {
            MaquiId = AddAutoIncrementColumn(table,"MaquiId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> MaquiId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
