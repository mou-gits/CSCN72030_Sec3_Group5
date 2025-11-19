using Microsoft.Data.Sqlite;
using System;
namespace DormClimateBackend.Services
{
    public class ExternalTemperatureService
    {
        private readonly string _connectionString;
        private readonly bool _useConstantTemperature;
        private readonly double? _constantTemperature;

        // Existing constructor — unchanged behavior
        public ExternalTemperatureService(string dbPath)
            : this(dbPath, false, null) { }

        // New constructor with constant override support
        public ExternalTemperatureService(string dbPath, bool useConstantTemperature, double? constantTemperature)
        {
            _connectionString = $"Data Source={dbPath}";
            _useConstantTemperature = useConstantTemperature;
            _constantTemperature = constantTemperature;
        }

        public double? GetInterpolatedTemperature(DateTime targetTime)
        {
            if (_useConstantTemperature && _constantTemperature.HasValue)
            {
                return _constantTemperature;
            }

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string timeOnly = targetTime.ToString("HH:mm:ss");

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                            SELECT time, temperature FROM ExternalTemperature
                            WHERE time <= @targetTime
                            ORDER BY time DESC
                            LIMIT 1;";
            cmd.Parameters.AddWithValue("@targetTime", timeOnly);

            TimeSpan? t1 = null;
            double? temp1 = null;

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    t1 = TimeSpan.Parse(reader.GetString(0));
                    temp1 = reader.GetDouble(1);
                }
            }

            cmd.CommandText = @"
                            SELECT time, temperature FROM ExternalTemperature
                            WHERE time > @targetTime
                            ORDER BY time ASC
                            LIMIT 1;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@targetTime", timeOnly);

            TimeSpan? t2 = null;
            double? temp2 = null;

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    t2 = TimeSpan.Parse(reader.GetString(0));
                    temp2 = reader.GetDouble(1);
                }
            }

            TimeSpan targetSpan = targetTime.TimeOfDay;

            if (t1.HasValue && t2.HasValue && temp1.HasValue && temp2.HasValue)
            {
                double fraction = (targetSpan - t1.Value).TotalSeconds / (t2.Value - t1.Value).TotalSeconds;
                return temp1.Value + fraction * (temp2.Value - temp1.Value);
            }

            return temp1 ?? temp2;
        }
    }

}