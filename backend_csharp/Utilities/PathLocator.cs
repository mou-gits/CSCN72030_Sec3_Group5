using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormClimateBackend.Utilities
{
    public static class PathLocator
    {
        public static string LocateDBPath(string path, string filename)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path cannot be null or empty.", nameof(path));

            // Case 1: Path is a file → return directly
            if (File.Exists(path))
                return path;

            // Case 2: Path is a folder → check for filename
            if (Directory.Exists(path))
            {
                string directFile = Path.Combine(path, filename);
                string dbFolderFile = Path.Combine(path, "database", filename);

                bool directExists = File.Exists(directFile);
                bool dbExists = File.Exists(dbFolderFile);

                if (directExists && dbExists)
                    return dbFolderFile; // prefer /database/ version
                if (dbExists)
                    return dbFolderFile;
                if (directExists)
                    return directFile;

                throw new FileNotFoundException(
                    $"Could not find {filename} in '{path}' or '{Path.Combine(path, "database")}'.");
            }

            // Neither file nor folder exists
            throw new FileNotFoundException($"Path does not exist: {path}");
        }
    }
}
