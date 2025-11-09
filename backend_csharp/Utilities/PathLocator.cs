using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormClimateBackend.Utilities
{
    public static class PathLocator
    {
        public static string LocateDBPath(string? overridePath = null)
        {
            if (!string.IsNullOrWhiteSpace(overridePath))
            {
                if (!File.Exists(overridePath))
                    throw new FileNotFoundException($"Override database path not found: {overridePath}");

                return overridePath;
            }

            // Use a known relative path from the current working directory
            var candidatePaths = new[]
            {
        Path.Combine(Directory.GetCurrentDirectory(), "database", "DormClimate.db"),
        Path.Combine(AppContext.BaseDirectory, "database", "DormClimate.db")
    };

            foreach (var path in candidatePaths)
            {
                if (File.Exists(path))
                    return path;
            }

            throw new FileNotFoundException("Could not locate DormClimate.db in expected locations.");
        }
    }
}
