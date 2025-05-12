using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Data.SqlClient;
using ProiectPAOO.Models;

namespace ProiectPAOO.Repositories
{

    internal class ClientRepository
    {
        private readonly string _connectionString = "Data Source=DESKTOP-LL53UKA\\SQLEXPRESS;Initial Catalog=paoo;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

        public void AddToCart(int userId, int instrumentId)
        {
            try
            {
                string query = @"
                INSERT INTO ShoppingCart (UserId, InstrumentId, Quantity)
                VALUES (@UserId, @InstrumentId, 1);";
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@InstrumentId", instrumentId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error" + ex.Message);
            }

        }

        public List<Models.ShoppingCart> GetCartByUserId(int id)
        {
            var cart = new List<Models.ShoppingCart>();
            try
            {
                using(SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM ShoppingCart WHERE UserId=@UserId";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", id);
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Models.ShoppingCart shcart = new Models.ShoppingCart { 
                                   UserId = Convert.ToInt32(reader["UserId"]),
                                    InstrumentId = Convert.ToInt32(reader["InstrumentId"]),
                                    Quantity = Convert.ToInt32(reader["Quantity"])
                                };
                                cart.Add(shcart);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString());
            }
            return cart;
        }

        public void IncrementQuantity(int instrumentId)
        {
            string sql = "UPDATE ShoppingCart SET Quantity = Quantity + 1 WHERE InstrumentId=@id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", instrumentId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DecrementQuantity(int instrumentId)
        {
            string sql = "UPDATE ShoppingCart SET Quantity = Quantity - 1 WHERE InstrumentId=@id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", instrumentId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveItemFromCart(int instrumentId)
        {
            string sql = "DELETE FROM ShoppingCart WHERE InstrumentId=@id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", instrumentId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ClearCart()
        {
            string sql = "DELETE FROM ShoppingCart";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public int GetItemQuantity(int instrumentId)
        {
            string sql = "SELECT Quantity FROM ShoppingCart WHERE InstrumentId=@id";
            int quantity = 0;

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", instrumentId);
                conn.Open();
                quantity = (int)cmd.ExecuteScalar();  // Fetch the current quantity
            }

            return quantity;
        }

    }
}
