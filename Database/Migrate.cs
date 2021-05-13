using System;
using System.Reflection;
using Dapper;
using DbUp;
using Npgsql;

namespace Database
{
    internal class Migrate
    {
        private static int Main(string[] args)
        {
            // TODO - Use env variable
            var connectionString = "Server=db;Port=5432;Database=doot;User ID=postgres;Password=postgres";

            Console.WriteLine("Migrating Database...");

            var upgradeEngine = DeployChanges.To.PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly()).LogToConsole().Build();

            var result = upgradeEngine.PerformUpgrade();

            if (!result.Successful)
            {
                Console.Error.WriteLine("Error migrating database");
                return -1;
            }

            Console.WriteLine("Database migrated successfully.");
            return 0;
        }
    }
}