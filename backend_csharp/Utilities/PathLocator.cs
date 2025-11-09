using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormClimateBackend.Utilities
{
    public static class PathLocator
    {
        public static string LocateDBPath()
        {
            var directoryInfo = new DirectoryInfo(AppContext.BaseDirectory);
            var projectRoot = directoryInfo.Parent?.Parent?.Parent?.Parent?.FullName
                ?? throw new InvalidOperationException("Could not determine project root directory.");

            var dbPath = Path.Combine(projectRoot, "database", "DormClimate.db");

            if (!File.Exists(dbPath))
                throw new FileNotFoundException($"Database not found at: {dbPath}");

            return dbPath;
        }
    }
}
