using System;
using System.IO;
using GuessingGame.Shared;
using GuessingGame.Shared.Properties;
using Microsoft.EntityFrameworkCore;

namespace GuessingGame.Gui.ConsoleApplication {
    public class LogContext : DbContext {
        private readonly string _pathToFile = Path.Combine(Resources.GameDirectory, "log.db");
        private string FullPathToFile => Environment.ExpandEnvironmentVariables(_pathToFile);
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //optionsBuilder.UseSqlServer(Resources.SqlServerConnectionString);
            optionsBuilder.UseSqlite($"Data Source={FullPathToFile}");
            //optionsBuilder.UseInMemoryDatabase("GuessingGame");
        }
    }
}