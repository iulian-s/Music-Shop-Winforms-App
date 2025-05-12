using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProiectPAOO.Models;

namespace ProiectPAOO.Repositories
{
    internal class LogRepository
    {
        private readonly string _connectionString = "Data Source=DESKTOP-LL53UKA\\SQLEXPRESS;Initial Catalog=paoo;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

        public List <PurchaseLog> GetLogs()
        {
            var logs = new List<PurchaseLog>();
            try
            {
                using(SqlConnection conn = new SqlConnection(this._connectionString))
                {
                    string sql = "SELECT * FROM PurchaseLog";
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PurchaseLog log = new PurchaseLog
                                {
                                    Id = reader.GetInt32(0),
                                    UserId = reader.GetInt32(1),
                                    InstrumentId = reader.GetInt32(2),
                                    Quantity = reader.GetInt32(3),
                                    PurchaseDate = reader.GetDateTime(4),
                                    TotalPrice = reader.GetDecimal(5),
                                    OrderStatus = reader["OrderStatus"].ToString(),
                                    ShippingAddress = reader["ShippingAddress"].ToString(),
                                };
                                logs.Add(log);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }
            return logs;
        }

        public void UpdateStatus(int id,  string status)
        {
            string query = "UPDATE PurchaseLog SET OrderStatus=@OrderStatus WHERE Id=@Id";
            using(SqlConnection conn = new SqlConnection(this._connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("OrderStatus", status);
                cmd.Parameters.AddWithValue("Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Dictionary<string, int> GetSalesChartByCategory()
        {
            var result = new Dictionary<string, int>();
            using(SqlConnection conn =new SqlConnection(this._connectionString))
            {
                string query = @"SELECT i.Category, SUM(s.Quantity) AS TotalSales
                                 FROM PurchaseLog s
                                 JOIN Instruments i ON s.InstrumentId = i.Id
                                 WHERE s.PurchaseDate >= DATEADD(DAY, -30, GETDATE())
                                 GROUP BY i.Category";
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query,conn)) 
                    using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string category = reader.GetString(0);
                        int total = reader.GetInt32(1);
                        result[category] = total;
                    }
                }
            }
            return result;
        }

        public void AddLog(int userId, List<Models.ShoppingCart> cart, string shippingAddress, decimal totalPrice)
        {
            try
            {
                string query = @"
        INSERT INTO PurchaseLog (UserId, InstrumentId, Quantity, PurchaseDate, TotalPrice, ShippingAddress)
        VALUES (@UserId, @InstrumentId, @Quantity, @PurchaseDate, @TotalPrice, @ShippingAddress);";

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    foreach (var item in cart)
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.Parameters.AddWithValue("@InstrumentId", item.InstrumentId);
                            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@PurchaseDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                            cmd.Parameters.AddWithValue("@ShippingAddress", shippingAddress);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error" + ex.Message);
            }

        }

        public List<PurchaseLog> GetLogsByUserId(int id)
        {
            var logs = new List<PurchaseLog>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this._connectionString))
                {
                    string sql = "SELECT * FROM PurchaseLog WHERE UserId=@id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PurchaseLog log = new PurchaseLog
                                {
                                    Id = reader.GetInt32(0),
                                    UserId = reader.GetInt32(1),
                                    InstrumentId = reader.GetInt32(2),
                                    Quantity = reader.GetInt32(3),
                                    PurchaseDate = reader.GetDateTime(4),
                                    TotalPrice = reader.GetDecimal(5),
                                    OrderStatus = reader["OrderStatus"].ToString(),
                                    ShippingAddress = reader["ShippingAddress"].ToString(),
                                };
                                logs.Add(log);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return logs;
        }
        public void CancelOrder(int id)
        {
            string query = "UPDATE PurchaseLog SET OrderStatus='Canceled' WHERE Id=@Id";
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
               
                cmd.Parameters.AddWithValue("Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Dictionary<string, int> GetMonthlySalesForYear(int year)
        {
            string query = @"
        SELECT DATENAME(MONTH, PurchaseDate) AS MonthName, SUM(Quantity) AS Total
        FROM PurchaseLog
        WHERE YEAR(PurchaseDate) = @Year
        GROUP BY DATENAME(MONTH, PurchaseDate), MONTH(PurchaseDate)
        ORDER BY MONTH(PurchaseDate);";

            var result = new Dictionary<string, int>();

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Year", year);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string month = reader.GetString(0);
                        int total = reader.GetInt32(1);
                        result[month] = total;
                    }
                }
            }

            return result;
        }

        public void ExportSalesByCategoryToCsv(string filePath)
        {
            var salesData = new LogRepository().GetSalesChartByCategory();

            var lines = new List<string>
    {
        "Category,Total Sold"
    };

            foreach (var entry in salesData)
            {
                lines.Add($"{entry.Key},{entry.Value}");
            }

            File.WriteAllLines(filePath, lines);
        }

    }
}
