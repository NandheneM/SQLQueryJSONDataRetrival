using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLQueryDataRetrival
{    public static class AppSettings
    {
        public const string ConnectionString = "SQLCOnnectionString";
        public const string Query = "SELECT JSONCol FROM TABLE WHERE CONDITION";
        public const string ColumnName = "JSONCol";

        public const string OutputDirectory = @"C:\Users\PB123XY\Downloads\SQLQueryResult\";
        public const string OutputFileBaseName = "QueryResult";

        public static string GetTimestampedOutputPath()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            return $"{OutputDirectory}{OutputFileBaseName}_{timestamp}.txt";
        }

    }

}
