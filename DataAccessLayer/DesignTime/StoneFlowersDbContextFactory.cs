using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace AccessLayer.DesignTime
{
    public class StoneFlowersDbContextFactory : IDesignTimeDbContextFactory<StoneFlowersDbContext>
    {
        public StoneFlowersDbContext CreateDbContext(string[] args)
        {
            // Try to locate appsettings.json in possible startup project locations
            var baseDir = Directory.GetCurrentDirectory();
            var candidates = new[] {
                baseDir,
                Path.Combine(baseDir, ".."),
                Path.Combine(baseDir, "..", ".."),
                Path.Combine(baseDir, "..", "..", ".."),
                Path.Combine(baseDir, "..", "StoneFlowersApi"),
                Path.Combine(baseDir, "StoneFlowersApi")
            };

            var configDir = candidates.FirstOrDefault(d => File.Exists(Path.Combine(d, "appsettings.json")));

            // Prefer environment variables to avoid adding configuration package dependencies in the library
            string? connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__StoneFlowerConnection")
                                       ?? Environment.GetEnvironmentVariable("STONEFLOWER_CONNECTION");

            // Fallback to reading appsettings.json manually if env var not set
            if (string.IsNullOrWhiteSpace(connectionString) && configDir != null)
            {
                try
                {
                    var json = File.ReadAllText(Path.Combine(configDir, "appsettings.json"));
                    using var doc = System.Text.Json.JsonDocument.Parse(json);
                    if (doc.RootElement.TryGetProperty("ConnectionStrings", out var cs) &&
                        cs.TryGetProperty("StoneFlowerConnection", out var val))
                    {
                        connectionString = val.GetString();
                    }
                }
                catch
                {
                    // ignore parse errors and let later code throw a clear error
                }
            }

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Could not find a connection string for 'StoneFlowerConnection'. Please set it in appsettings.json or as env var 'ConnectionStrings__StoneFlowerConnection'.");

            var optionsBuilder = new DbContextOptionsBuilder<StoneFlowersDbContext>();
            optionsBuilder.UseNpgsql(connectionString, b => b.MigrationsAssembly("DataAccessLayer"));

            return new StoneFlowersDbContext(optionsBuilder.Options);
        }
    }
}
