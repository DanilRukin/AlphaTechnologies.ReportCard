using AlphaTechnologies.ReportCard.Presentation.WPF.Infrastructure.Configuration.DatabaseProfiles.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.Infrastructure.Configuration.DatabaseProfiles
{
    public class MySqlDatabaseProfile : DatabaseProfile
    {
        public string MigrationAssembly { get; protected set; }

        public MySqlDatabaseProfile(string name, string connectionString, bool useSeedData,
            bool migrateDatabase, bool createDatabase, string migrationAssembly)
            : base(name, connectionString, useSeedData, migrateDatabase, createDatabase)
        {
            MigrationAssembly = migrationAssembly;
        }

        public override void ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL(ConnectionString, sql => sql.MigrationsAssembly(MigrationAssembly));
        }
    }
}
