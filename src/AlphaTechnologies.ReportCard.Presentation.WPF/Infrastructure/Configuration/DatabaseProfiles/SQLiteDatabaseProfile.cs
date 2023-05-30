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
        private SqliteConnection _connection;
        public SQLiteDatabaseProfile(string name, string connectionString, bool useSeedData,
            bool migrateDatabase, bool createDatabase) :
            base(name, connectionString, useSeedData, migrateDatabase, createDatabase)
        {
        }

        public override void ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder builder)
        {
            _connection = new SqliteConnection(ConnectionString);
            _connection.Open();
            builder.UseSqlite(_connection);
        }
    }
}
