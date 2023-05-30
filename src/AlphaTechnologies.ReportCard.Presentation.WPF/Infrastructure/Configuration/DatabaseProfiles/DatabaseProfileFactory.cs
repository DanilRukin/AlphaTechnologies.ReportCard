using AlphaTechnologies.ReportCard.Presentation.WPF.Infrastructure.Configuration.DatabaseProfiles.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.Infrastructure.Configuration.DatabaseProfiles
{
    public class DatabaseProfileFactory
    {
        public DatabaseProfile CreateFromConfiguration(IConfiguration configuration)
        {
            string profileName = configuration["UseProfile"];
            var section = configuration.GetSection("Profiles");
            var profile = section.GetSection(profileName);
            string connectionString = profile[nameof(DatabaseProfile.ConnectionString)];
            bool useSeedData = FromString(profile[nameof(DatabaseProfile.UseSeedData)]);
            bool migrateDatabase = FromString(profile[nameof(DatabaseProfile.MigrateDatabase)]);
            bool createDatabase = FromString(profile[nameof(DatabaseProfile.CreateDatabase)]);
            if (profileName == "MySqlProfile")
            {
                string migrationAssembly = profile[nameof(MySqlDatabaseProfile.MigrationAssembly)];
                return new MySqlDatabaseProfile(profileName, connectionString, useSeedData,
                    migrateDatabase, createDatabase, migrationAssembly);
            }
            else if (profileName == "SQLiteProfile")
            {
                return new SQLiteDatabaseProfile(profileName, connectionString, useSeedData,
                    migrateDatabase, createDatabase);
            }
            else
            {
                throw new InvalidOperationException($"Unable to create '{profileName}'" +
                    $" database profile");
            }
        }
        protected bool FromString(string value) => value == "true" ? true : false;
    }
}
