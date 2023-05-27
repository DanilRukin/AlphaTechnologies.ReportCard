using AlphaTechnologies.ReportCard.Data;
using AlphaTechnologies.ReportCard.SharedKernel.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.IntegrationTests.Data
{
    public class EfCoreBaseFixture
    {
        protected SqliteConnection _connection;
        protected AlphaTechnologiesRepordCardDbContext GetClearContext()
        {
            var options = CreateDbContextOptions();
            var mockEventDispatcher = new Mock<IDomainEventDispatcher>();

            return new AlphaTechnologiesRepordCardDbContext(mockEventDispatcher.Object, options);
        }

        protected DbContextOptions<AlphaTechnologiesRepordCardDbContext> CreateDbContextOptions()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();
            

            var builder = new DbContextOptionsBuilder<AlphaTechnologiesRepordCardDbContext>();
            builder.UseSqlite(_connection);

            return builder.Options;
        }
    }
}
