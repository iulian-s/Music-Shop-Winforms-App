using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using ProiectPAOO.Models;

namespace ProiectPAOO.Repositories
{
    internal class InstrumentRepository
    {
        private readonly string _connectionString = "Data Source=DESKTOP-LL53UKA\\SQLEXPRESS;Initial Catalog=paoo;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

        //ADDING METHODS
        public void AddStringedInstrument(Instruments instrument, StringedInstruments stringed)
        {
            string insertInstrumentQuery = @"
                INSERT INTO Instruments (Name, Brand, Color, Price, Stock, Category, ImagePath)
                OUTPUT INSERTED.Id
                VALUES (@Name, @Brand, @Color, @Price, @Stock, @Category, @ImagePath);";

            string insertStringedQuery = @"
                INSERT INTO StringedInstruments (InstrumentId, NumberOfStrings, Type, Scale, Frets, Wood)
                VALUES (@InstrumentId, @NumberOfStrings, @Type, @Scale, @Frets, @Wood);";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    int newInstrumentId;
                    using (SqlCommand cmd = new SqlCommand(insertInstrumentQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Name", instrument.Name);
                        cmd.Parameters.AddWithValue("@Brand", instrument.Brand);
                        cmd.Parameters.AddWithValue("@Color", instrument.Color);
                        cmd.Parameters.AddWithValue("@Price", instrument.Price);
                        cmd.Parameters.AddWithValue("@Stock", instrument.Stock);
                        cmd.Parameters.AddWithValue("@Category", instrument.Category);
                        cmd.Parameters.AddWithValue("@ImagePath", instrument.ImagePath);

                        newInstrumentId = (int)cmd.ExecuteScalar();
                    }
                    using (SqlCommand cmd = new SqlCommand(insertStringedQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@InstrumentId", newInstrumentId);
                        cmd.Parameters.AddWithValue("@NumberOfStrings", stringed.NumberOfStrings);
                        cmd.Parameters.AddWithValue("@Type", stringed.Type);
                        cmd.Parameters.AddWithValue("@Scale", stringed.Scale);
                        cmd.Parameters.AddWithValue("@Frets", stringed.Frets);
                        cmd.Parameters.AddWithValue("@Wood", stringed.Wood);
                        

                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("SQL Error" + ex.Message);
                }
                
            }
        }
        public void AddKeyboardInstrument(Instruments instrument, KeyboardInstruments keyboard)
        {
            string insertInstrumentQuery = @"
                INSERT INTO Instruments (Name, Brand, Color, Price, Stock, Category, ImagePath)
                OUTPUT INSERTED.Id
                VALUES (@Name, @Brand, @Color, @Price, @Stock, @Category, @ImagePath);";

            string insertStringedQuery = @"
                INSERT INTO KeyboardInstruments (InstrumentId, KeysCount, IsDigital)
                VALUES (@InstrumentId, @KeysCount, @IsDigital);";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    int newInstrumentId;
                    using (SqlCommand cmd = new SqlCommand(insertInstrumentQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Name", instrument.Name);
                        cmd.Parameters.AddWithValue("@Brand", instrument.Brand);
                        cmd.Parameters.AddWithValue("@Color", instrument.Color);
                        cmd.Parameters.AddWithValue("@Price", instrument.Price);
                        cmd.Parameters.AddWithValue("@Stock", instrument.Stock);
                        cmd.Parameters.AddWithValue("@Category", instrument.Category);
                        cmd.Parameters.AddWithValue("@ImagePath", instrument.ImagePath);

                        newInstrumentId = (int)cmd.ExecuteScalar();
                    }
                    using (SqlCommand cmd = new SqlCommand(insertStringedQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@InstrumentId", newInstrumentId);
                        cmd.Parameters.AddWithValue("@KeysCount", keyboard.KeysCount);
                        cmd.Parameters.AddWithValue("@IsDigital", keyboard.IsDigital);
                       
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("SQL Error" + ex.Message);
                }

            }
        }

        public void AddBlowingInstrument(Instruments instrument, BlowingInstruments sax)
        {
            string insertInstrumentQuery = @"
                INSERT INTO Instruments (Name, Brand, Color, Price, Stock, Category, ImagePath)
                OUTPUT INSERTED.Id
                VALUES (@Name, @Brand, @Color, @Price, @Stock, @Category, @ImagePath);";

            string insertStringedQuery = @"
                INSERT INTO BlowingInstruments (InstrumentId, Material, KeyType, Tuning)
                VALUES (@InstrumentId, @Material, @KeyType, @Tuning);";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    int newInstrumentId;
                    using (SqlCommand cmd = new SqlCommand(insertInstrumentQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Name", instrument.Name);
                        cmd.Parameters.AddWithValue("@Brand", instrument.Brand);
                        cmd.Parameters.AddWithValue("@Color", instrument.Color);
                        cmd.Parameters.AddWithValue("@Price", instrument.Price);
                        cmd.Parameters.AddWithValue("@Stock", instrument.Stock);
                        cmd.Parameters.AddWithValue("@Category", instrument.Category);
                        cmd.Parameters.AddWithValue("@ImagePath", instrument.ImagePath);

                        newInstrumentId = (int)cmd.ExecuteScalar();
                    }
                    using (SqlCommand cmd = new SqlCommand(insertStringedQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@InstrumentId", newInstrumentId);
                        cmd.Parameters.AddWithValue("@Material", sax.Material);
                        cmd.Parameters.AddWithValue("@KeyType", sax.KeyType);
                        cmd.Parameters.AddWithValue("@Tuning", sax.Tuning);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("SQL Error" + ex.Message);
                }

            }
        }

        public void AddDrums(Instruments instrument, Drums drum)
        {
            string insertInstrumentQuery = @"
                INSERT INTO Instruments (Name, Brand, Color, Price, Stock, Category, ImagePath)
                OUTPUT INSERTED.Id
                VALUES (@Name, @Brand, @Color, @Price, @Stock, @Category, @ImagePath);";

            string insertStringedQuery = @"
                INSERT INTO Drums (InstrumentId, DrumType, IsElectric, NumberOfDrums)
                VALUES (@InstrumentId, @DrumType, @IsElectric, @NumberOfDrums);";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    int newInstrumentId;
                    using (SqlCommand cmd = new SqlCommand(insertInstrumentQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Name", instrument.Name);
                        cmd.Parameters.AddWithValue("@Brand", instrument.Brand);
                        cmd.Parameters.AddWithValue("@Color", instrument.Color);
                        cmd.Parameters.AddWithValue("@Price", instrument.Price);
                        cmd.Parameters.AddWithValue("@Stock", instrument.Stock);
                        cmd.Parameters.AddWithValue("@Category", instrument.Category);
                        cmd.Parameters.AddWithValue("@ImagePath", instrument.ImagePath);

                        newInstrumentId = (int)cmd.ExecuteScalar();
                    }
                    using (SqlCommand cmd = new SqlCommand(insertStringedQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@InstrumentId", newInstrumentId);
                        cmd.Parameters.AddWithValue("@DrumType", drum.DrumType);
                        cmd.Parameters.AddWithValue("@IsElectric", drum.IsElectric);
                        cmd.Parameters.AddWithValue("@NumberOfDrums", drum.NumberOfDrums);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("SQL Error" + ex.Message);
                }

            }
        }

        //UPDATING METHODS
        public void UpdateStringedInstrument(Instruments instrument, StringedInstruments stringed)
        {
            string insertInstrumentQuery = @"
                UPDATE Instruments
                SET Name=@Name, Brand=@Brand, Color=@Color, Price=@Price, Stock=@Stock, Category=@Category, ImagePath=@ImagePath
                WHERE Id=@Id";

            string insertStringedQuery = @"
                UPDATE StringedInstruments
                SET NumberOfStrings=@NumberOfStrings, Type=@Type, Scale=@Scale, Frets=@Frets, Wood=@Wood
                WHERE InstrumentId=@Id";
                
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    
                    using (SqlCommand cmd = new SqlCommand(insertInstrumentQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Name", instrument.Name);
                        cmd.Parameters.AddWithValue("@Brand", instrument.Brand);
                        cmd.Parameters.AddWithValue("@Color", instrument.Color);
                        cmd.Parameters.AddWithValue("@Price", instrument.Price);
                        cmd.Parameters.AddWithValue("@Stock", instrument.Stock);
                        cmd.Parameters.AddWithValue("@Category", instrument.Category);
                        cmd.Parameters.AddWithValue("@ImagePath", instrument.ImagePath);
                        cmd.Parameters.AddWithValue("@Id", instrument.Id);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(insertStringedQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@NumberOfStrings", stringed.NumberOfStrings);
                        cmd.Parameters.AddWithValue("@Type", stringed.Type);
                        cmd.Parameters.AddWithValue("@Scale", stringed.Scale);
                        cmd.Parameters.AddWithValue("@Frets", stringed.Frets);
                        cmd.Parameters.AddWithValue("@Wood", stringed.Wood);
                        cmd.Parameters.AddWithValue("@Id", instrument.Id);

                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("SQL Error" + ex.Message);
                }

            }
        }

        public void UpdateKeyboardInstrument(Instruments instrument, KeyboardInstruments keyboard)
        {
            string insertInstrumentQuery = @"
                UPDATE Instruments
                SET Name=@Name, Brand=@Brand, Color=@Color, Price=@Price, Stock=@Stock, Category=@Category, ImagePath=@ImagePath
                WHERE Id=@Id";

            string insertStringedQuery = @"
                UPDATE KeyboardInstruments
                SET KeysCount=@KeysCount, IsDigital=@IsDigital
                WHERE InstrumentId=@Id";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {

                    using (SqlCommand cmd = new SqlCommand(insertInstrumentQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Name", instrument.Name);
                        cmd.Parameters.AddWithValue("@Brand", instrument.Brand);
                        cmd.Parameters.AddWithValue("@Color", instrument.Color);
                        cmd.Parameters.AddWithValue("@Price", instrument.Price);
                        cmd.Parameters.AddWithValue("@Stock", instrument.Stock);
                        cmd.Parameters.AddWithValue("@Category", instrument.Category);
                        cmd.Parameters.AddWithValue("@ImagePath", instrument.ImagePath);
                        cmd.Parameters.AddWithValue("@Id", instrument.Id);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(insertStringedQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@KeysCount", keyboard.KeysCount);
                        cmd.Parameters.AddWithValue("@IsDigital",keyboard.IsDigital);
                        cmd.Parameters.AddWithValue("@Id", instrument.Id);

                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("SQL Error" + ex.Message);
                }

            }
        }

        public void UpdateBlowingInstrument(Instruments instrument, BlowingInstruments sax)
        {
            string insertInstrumentQuery = @"
                UPDATE Instruments
                SET Name=@Name, Brand=@Brand, Color=@Color, Price=@Price, Stock=@Stock, Category=@Category, ImagePath=@ImagePath
                WHERE Id=@Id";

            string insertStringedQuery = @"
                UPDATE BlowingInstruments
                SET Material=@Material, KeyType=@KeyType, Tuning=@Tuning
                WHERE InstrumentId=@Id";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {

                    using (SqlCommand cmd = new SqlCommand(insertInstrumentQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Name", instrument.Name);
                        cmd.Parameters.AddWithValue("@Brand", instrument.Brand);
                        cmd.Parameters.AddWithValue("@Color", instrument.Color);
                        cmd.Parameters.AddWithValue("@Price", instrument.Price);
                        cmd.Parameters.AddWithValue("@Stock", instrument.Stock);
                        cmd.Parameters.AddWithValue("@Category", instrument.Category);
                        cmd.Parameters.AddWithValue("@ImagePath", instrument.ImagePath);
                        cmd.Parameters.AddWithValue("@Id", instrument.Id);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(insertStringedQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Material", sax.Material);
                        cmd.Parameters.AddWithValue("@KeyType", sax.KeyType);
                        cmd.Parameters.AddWithValue("@Tuning", sax.Tuning);
                        cmd.Parameters.AddWithValue("@Id", instrument.Id);

                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("SQL Error" + ex.Message);
                }

            }
        }

        public void UpdateDrums(Instruments instrument, Drums drum)
        {
            string insertInstrumentQuery = @"
                UPDATE Instruments
                SET Name=@Name, Brand=@Brand, Color=@Color, Price=@Price, Stock=@Stock, Category=@Category, ImagePath=@ImagePath
                WHERE Id=@Id";

            string insertStringedQuery = @"
                UPDATE Drums
                SET DrumType=@DrumType, IsElectric=@IsElectric, NumberOfDrums=@NumberOfDrums
                WHERE InstrumentId=@Id";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {

                    using (SqlCommand cmd = new SqlCommand(insertInstrumentQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Name", instrument.Name);
                        cmd.Parameters.AddWithValue("@Brand", instrument.Brand);
                        cmd.Parameters.AddWithValue("@Color", instrument.Color);
                        cmd.Parameters.AddWithValue("@Price", instrument.Price);
                        cmd.Parameters.AddWithValue("@Stock", instrument.Stock);
                        cmd.Parameters.AddWithValue("@Category", instrument.Category);
                        cmd.Parameters.AddWithValue("@ImagePath", instrument.ImagePath);
                        cmd.Parameters.AddWithValue("@Id", instrument.Id);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(insertStringedQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@DrumType", drum.DrumType);
                        cmd.Parameters.AddWithValue("@IsElectric", drum.IsElectric);
                        cmd.Parameters.AddWithValue("@NumberOfDrums",drum.NumberOfDrums);
                        cmd.Parameters.AddWithValue("@Id", instrument.Id);

                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("SQL Error" + ex.Message);
                }

            }
        }

        //DELETING METHODS
        public void DeleteStringedInstruments(int id)
        {
            string sql = "DELETE FROM Instruments WHERE Id=@id";
            string stringed_sql = "DELETE FROM StringedInstruments WHERE InstrumentId=@id";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(stringed_sql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    {
                        transaction.Rollback();
                        MessageBox.Show("SQL ERROR" + ex.Message);
                    }
                }
            }
        }

        public void DeleteKeyboardInstruments(int id)
        {
            string sql = "DELETE FROM Instruments WHERE Id=@id";
            string stringed_sql = "DELETE FROM KeyboardInstruments WHERE InstrumentId=@id";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(stringed_sql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    {
                        transaction.Rollback();
                        MessageBox.Show("SQL ERROR" + ex.Message);
                    }
                }
            }
        }


        public void DeleteBlowingInstruments(int id)
        {
            string sql = "DELETE FROM Instruments WHERE Id=@id";
            string stringed_sql = "DELETE FROM BlowingInstruments WHERE InstrumentId=@id";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(stringed_sql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    {
                        transaction.Rollback();
                        MessageBox.Show("SQL ERROR" + ex.Message);
                    }
                }
            }
        }

        public void DeleteDrums(int id)
        {
            string sql = "DELETE FROM Instruments WHERE Id=@id";
            string stringed_sql = "DELETE FROM Drums WHERE InstrumentId=@id";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(stringed_sql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    {
                        transaction.Rollback();
                        MessageBox.Show("SQL ERROR" + ex.Message);
                    }
                }
            }
        }

        public List<Instruments> GetInstruments()
        {
            var instruments = new List<Instruments>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string sql = "SELECT * FROM Instruments";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Instruments instrument = new Instruments
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader["Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    Color = reader["Color"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    Stock = Convert.ToInt32(reader["Stock"]),
                                    Category = reader["Category"].ToString(),
                                    ImagePath = reader["ImagePath"].ToString()
                                };
                                

                                Image img = null;
                                if (File.Exists(instrument.ImagePath))
                                {
                                    img = Image.FromFile(instrument.ImagePath);
                                    
                                }
                               instruments.Add(instrument);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString());
            }
            return instruments;
        }


        public Instruments GetInstrumentById(int id)
        {
            var instr = new Instruments();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Instruments WHERE Id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            instr.Id = Convert.ToInt32(reader["Id"]);
                            instr.Name = reader["Name"].ToString();
                            instr.Brand = reader["Brand"].ToString();
                            instr.Color = reader["Color"].ToString();
                            instr.Price = Convert.ToDecimal(reader["Price"]);
                            instr.Stock = Convert.ToInt32(reader["Stock"]);
                            instr.Category = reader["Category"].ToString();
                            instr.ImagePath = reader["ImagePath"].ToString();
                        }
                    }
                }
            }
            return instr;
        }

        public StringedInstruments GetStringedInstrumentsById(int id)
        {
            var stringed = new StringedInstruments();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM StringedInstruments WHERE InstrumentId=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stringed.NumberOfStrings = Convert.ToInt32(reader["NumberOfStrings"]);
                            stringed.Type = reader["Type"].ToString();
                            stringed.Scale = Convert.ToInt32(reader["Scale"]);
                            stringed.Frets = Convert.ToInt32(reader["Frets"]);
                            stringed.Wood = reader["Wood"].ToString();
                        }
                    }
                }
            }
            return stringed;
        }

        public KeyboardInstruments GetKeyboardInstrumentsById(int id)
        {
            var stringed = new KeyboardInstruments();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM KeyboardInstruments WHERE InstrumentId=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stringed.KeysCount = Convert.ToInt32(reader["KeysCount"]);
                            stringed.IsDigital = Convert.ToBoolean(reader["IsDigital"]);
                            
                        }
                    }
                }
            }
            return stringed;
        }


        public BlowingInstruments GetBlowingInstrumentsById(int id)
        {
            var stringed = new BlowingInstruments();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM BlowingInstruments WHERE InstrumentId=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stringed.Material = reader["Material"].ToString();
                            stringed.KeyType = reader["KeyType"].ToString();
                            stringed.Tuning = reader["Tuning"].ToString();

                        }
                    }
                }
            }
            return stringed;
        }


        public Drums GetDrumsById(int id)
        {
            var stringed = new Drums();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Drums WHERE InstrumentId=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stringed.DrumType = reader["DrumType"].ToString();
                            stringed.IsElectric = Convert.ToBoolean(reader["IsElectric"]);
                            stringed.NumberOfDrums = Convert.ToInt32(reader["NumberOfDrums"]);
                        }
                    }
                }
            }
            return stringed;
        }

        public List<Instruments> SearchInstruments(string query)
        {
            var instruments = new List<Instruments>();
            string sql = @"
        SELECT * FROM Instruments
        WHERE Stock > 0 AND 
              (Name LIKE @q OR Brand LIKE @q OR Category LIKE @q)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@q", "%" + query + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            instruments.Add(new Instruments
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Brand = reader["Brand"].ToString(),
                                Color = reader["Color"].ToString(),
                                Price = (decimal)reader["Price"],
                                Stock = (int)reader["Stock"],
                                Category = reader["Category"].ToString(),
                                ImagePath = reader["ImagePath"].ToString()
                            });
                        }
                    }
                }
            }

            return instruments;
        }

        

        

        public List<Instruments> CategoryFilter(string category, string orderBy, bool filterStock, decimal minPrice, decimal maxPrice, string color)
        {
            var list = new List<Instruments>();
            string sql = "SELECT * FROM Instruments WHERE 1=1";

            if (category != "All")
                sql += " AND Category LIKE @category";

            if (!string.IsNullOrEmpty(color))
            {
                sql += " AND Color LIKE @color";
                
            }


            if (filterStock)
                sql += " AND Stock > 0";

            sql += " AND Price >= @min AND Price <= @max";

            switch (orderBy)
            {
                case "Ascending (A-Z)": sql += " ORDER BY Name ASC"; break;
                case "Descending (A-Z)": sql += " ORDER BY Name DESC"; break;
                case "Price low to high": sql += " ORDER BY Price ASC"; break;
                case "Price high to low": sql += " ORDER BY Price DESC"; break;
            }

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (category != "All")
                    cmd.Parameters.AddWithValue("@category", "%" + category + "%");
                cmd.Parameters.AddWithValue("@color", "%" + color + "%");
                cmd.Parameters.AddWithValue("@min", minPrice);
                cmd.Parameters.AddWithValue("@max", maxPrice);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Instruments
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Brand = reader["Brand"].ToString(),
                            Color = reader["Color"].ToString(),
                            Price = (decimal)reader["Price"],
                            Stock = (int)reader["Stock"],
                            Category = reader["Category"].ToString(),
                            ImagePath = reader["ImagePath"].ToString()
                        });
                    }
                }
            }

            return list;
        }


    }
}
