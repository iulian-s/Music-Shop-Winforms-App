using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using ProiectPAOO.Models;

namespace ProiectPAOO.Repositories
{
    internal class UsersRepository
    {
        private readonly string _connectionString = "Data Source=DESKTOP-LL53UKA\\SQLEXPRESS;Initial Catalog=paoo;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

        public List<Users> GetUsers()
        {
            var users = new List<Users>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this._connectionString))
                {
                    string sql = "SELECT * FROM Users";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Users user = new Users
                                {
                                    Id = reader.GetInt32(0),
                                    Username = reader["Username"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    FullName = reader["FullName"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    Role = reader["Role"].ToString()
                                };
                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return users;
        }

        public void UpdateInfo(Users user)
        {
            string query = @"
        UPDATE Users
        SET Username=@Username, Password=@Password, Email=@Email, FullName=@FullName, PhoneNumber=@PhoneNumber, Address=@Address, Role=@Role
        WHERE Id=@Id";

            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Parameters correctly mapped
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Role", user.Role);  // Assuming Role is part of the User class
                cmd.Parameters.AddWithValue("@Id", user.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateInfoForClients(Users user)
        {
            string query = @"
        UPDATE Users
        SET Username=@Username, Password=@Password, Email=@Email, FullName=@FullName, PhoneNumber=@PhoneNumber, Address=@Address
        WHERE Id=@Id";

            using (SqlConnection conn = new SqlConnection(this._connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Parameters correctly mapped
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                 
                cmd.Parameters.AddWithValue("@Id", user.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public Users GetUserById(int id)
        {
            Users user = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(this._connectionString))
                {
                    string sql = "SELECT * FROM Users WHERE Id = @Id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new Users
                                {
                                    Id = reader.GetInt32(0),
                                    Username = reader["Username"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    FullName = reader["FullName"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    Role = reader["Role"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return user;
        }

        public Users GetUserByEmail(string email)
        {
            Users user = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(this._connectionString))
                {
                    string sql = "SELECT * FROM Users WHERE Email = @Email OR Username = @Email";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new Users
                                {
                                    Id = reader.GetInt32(0),
                                    Username = reader["Username"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    FullName = reader["FullName"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    Role = reader["Role"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return user;
        }

        public bool CheckLogin(string email, string password)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Users WHERE (Email=@email OR Username=@email) AND Password=@password";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            
        }

        public void CreateUser(Users user)
        {
            string query = @"
                INSERT INTO Users (Username, Password, Email)
                VALUES (@Username, @Password, @Email);";
            try
            {
                using(SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Password", user.Password);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        public bool IsValidEmail(string email)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
                return false;

            
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count == 0; // true if email is unique
                }
            }
        }


        public bool UsernameExists(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return true; 
            }
        }

    }
}
