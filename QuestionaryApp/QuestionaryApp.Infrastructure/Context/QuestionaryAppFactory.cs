using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace QuestionaryApp.Infrastructure.Data.Context
{
    public class QuestionaryAppFactory : IDesignTimeDbContextFactory<QuestionaryAppDbContext>
    {
        public QuestionaryAppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSetting.json")
                .Build();

            var builder = new DbContextOptionsBuilder<QuestionaryAppDbContext>();
            var connectionString = configuration.GetConnectionString("LocalConnection");

            builder.UseSqlServer(connectionString);
            return QuestionaryAppDbContext.GetInstanceForFactory(builder.Options);

        }
    }
}
