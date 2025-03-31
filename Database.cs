using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DataToSQLiteAI
{
    public class Database
    {
        public static void SaveDataToSQLite(List<IndexRate> data)
        {
            using (var connection = new SQLiteConnection("Data Source=mydatabase.db;Version=3;"))
            {
                connection.Open();

                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS IndexRates (
                IndexNo TEXT,
                EffectiveDate TEXT,
                Rate REAL
            )";
                var createTableCmd = new SQLiteCommand(createTableQuery, connection);
                createTableCmd.ExecuteNonQuery();

                foreach (var item in data)
                {
                    string insertQuery = "INSERT INTO IndexRates (IndexNo, EffectiveDate, Rate) VALUES (@IndexNo, @EffectiveDate, @Rate)";
                    var cmd = new SQLiteCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@IndexNo", item.IndexNo);
                    cmd.Parameters.AddWithValue("@EffectiveDate", item.EffectiveDate);
                    cmd.Parameters.AddWithValue("@Rate", item.Rate);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void GetDataFromDatabase()
        {
            using (var connection = new SQLiteConnection("Data Source=mydatabase.db;Version=3;"))
            {
                connection.Open();
                string query = "SELECT * FROM IndexRates";
                var command = new SQLiteCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"IndexNo: {reader["IndexNo"]}, EffectiveDate: {reader["EffectiveDate"]}, Rate: {reader["Rate"]}");
                    }
                }
            }
        }
    }
}
