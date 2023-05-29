using AlphaTechnologies.ReportCard.Presentation.WPF.Infrastructure.Configuration.DatabaseProfiles.Base;
using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Presentation.WPF.Infrastructure.Configuration.DatabaseProfiles
{
    public class SQLiteDatabaseProfile : DatabaseProfile
    {
        public SQLiteDatabaseProfile(IConfiguration configuration) : base(configuration) { }
        public override void ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder builder)
        {
            var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            builder.UseSqlite(connection);
        }
    }
}
