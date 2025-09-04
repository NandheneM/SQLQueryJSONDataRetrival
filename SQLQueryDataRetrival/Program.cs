using Microsoft.Data.SqlClient;
using SQLQueryDataRetrival;
using System;
using System.IO;

namespace SQLQueryDataRetrival
{
    class Program
    {
        static void Main()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(AppSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(AppSettings.Query, connection))
                {
                    connection.Open();
                    string outputPath = AppSettings.GetTimestampedOutputPath();

                    using (SqlDataReader reader = command.ExecuteReader())
                    using (StreamWriter writer = new StreamWriter(outputPath, false, System.Text.Encoding.UTF8))
                    {
                        while (reader.Read())
                        {
                            string? jsonContent = reader[AppSettings.ColumnName] != DBNull.Value
                                ? reader[AppSettings.ColumnName].ToString()
                                : string.Empty;

                            writer.WriteLine(jsonContent);
                        }
                    }
                }

                Console.WriteLine($"Export completed. File saved in outputPath");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
