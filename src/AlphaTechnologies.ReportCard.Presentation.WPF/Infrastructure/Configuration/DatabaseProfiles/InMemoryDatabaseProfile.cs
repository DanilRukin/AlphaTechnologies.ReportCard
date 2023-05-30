using AlphaTechnologies.ReportCard.Presentation.WPF.Infrastructure.Configuration.DatabaseProfiles.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.Infrastructure.Configuration.DatabaseProfiles
{
    public class InMemoryDatabaseProfile : DatabaseProfile
    {
        public InMemoryDatabaseProfile(string name, string connectionString, bool useSeedData, bool migrateDatabase, bool createDatabase) :
            base(name, connectionString, useSeedData, migrateDatabase, createDatabase)
        {
        }

        public override void ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase(ConnectionString);
        }
    }
}
