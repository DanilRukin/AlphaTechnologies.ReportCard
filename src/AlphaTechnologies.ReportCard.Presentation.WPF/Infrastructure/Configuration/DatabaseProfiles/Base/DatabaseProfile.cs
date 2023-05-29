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

        protected DatabaseProfile(IConfiguration configuration)
        {
            string profileName = configuration["UseProfile"];
            Name = profileName;
            var section = configuration.GetSection("Profiles");
            var profile = section.GetSection(Name);
            ConnectionString = profile[nameof(ConnectionString)];
            UseSeedData = FromString(profile[nameof(UseSeedData)]);
            MigrateDatabase = FromString(profile[nameof(MigrateDatabase)]);
            CreateDatabase = FromString(profile[nameof(CreateDatabase)]);
        }

        protected bool FromString(string value) => value == "true" ? true : false;
        public abstract void ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder builder);
    }
}
