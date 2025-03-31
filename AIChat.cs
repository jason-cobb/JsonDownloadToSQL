using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DataToSQLiteAI
{
    public class AIChat
    {
        public static string QueryIndexRate(string indexNo)
        {
            using (var connection = new SQLiteConnection("Data Source=mydatabase.db;Version=3;"))
            {
                connection.Open();
                string query = "SELECT * FROM IndexRates WHERE IndexNo = @IndexNo";
                var cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@IndexNo", indexNo);

                using (var reader = cmd.ExecuteReader())
                {
                    string result = "";
                    while (reader.Read())
                    {
                        result += $"IndexNo: {reader["IndexNo"]}, EffectiveDate: {reader["EffectiveDate"]}, Rate: {reader["Rate"]}\n";
                    }
                    return result;
                }
            }
        }

    }
}
