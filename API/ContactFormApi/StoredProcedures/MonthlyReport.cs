using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ContactFormApi.StoredProcedures
{
    public class MonthlyReport
    {
        private readonly string _connectionString;

        public MonthlyReport(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<MonthlyReportResult>> GetMonthlyReportAsync()
        {
            var results = new List<MonthlyReportResult>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_GetMonthlyReport", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var result = new MonthlyReportResult
                            {
                                Month = reader.GetString(0),
                                TotalSubmissions = reader.GetInt32(1)
                            };
                            results.Add(result);
                        }
                    }
                }
            }

            return results;
        }
    }

    public class MonthlyReportResult
    {
        public string Month { get; set; }
        public int TotalSubmissions { get; set; }
    }
}