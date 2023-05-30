using AlphaTechnologies.ReportCard.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.Infrastructure.Configuration.DatabaseProfiles.Base
{
    public abstract class DatabaseProfile
    {
        public string Name { get; protected set; }
        public string ConnectionString { get; protected set; }
        public bool UseSeedData { get; protected set; }
        public bool MigrateDatabase { get; protected set; }
        public bool CreateDatabase { get; protected set; }

        protected DatabaseProfile(string name, string connectionString, bool useSeedData,
            bool migrateDatabase, bool createDatabase) 
        {
            Name = name;
            ConnectionString = connectionString;
            UseSeedData = useSeedData;
            MigrateDatabase = migrateDatabase;
            CreateDatabase = createDatabase;
        }

        protected DatabaseProfile(IConfiguration configuration)
        {
            
        }

        
        public abstract void ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder builder);

        public virtual void UseDbContext(AlphaTechnologiesRepordCardDbContext context)
        {
            if (UseSeedData)
            {
                if (MigrateDatabase)
                {
                    SeedData.ApplyMigrationAndFillDatabase(context);
                }
                else if (CreateDatabase)
                {
                    SeedData.InitializeDatabase(context);
                }
            }
        }
    }
}
