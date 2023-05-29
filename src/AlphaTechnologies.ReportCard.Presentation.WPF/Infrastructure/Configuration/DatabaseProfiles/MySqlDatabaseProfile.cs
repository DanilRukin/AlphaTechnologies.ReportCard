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
        public MySqlDatabaseProfile(IConfiguration configuration) : base(configuration)
        {
            var section = configuration.GetSection("Profiles");
            var profile = section.GetSection(Name);
            MigrationAssembly = profile[nameof(MigrationAssembly)];
        }
        public override void ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL(ConnectionString, sql => sql.MigrationsAssembly(MigrationAssembly));
        }
    }
}
