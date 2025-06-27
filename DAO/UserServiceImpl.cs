using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace DAO
{
    public class UserServiceImpl : UserService
    {
        private SqlConnection connection;

        public UserServiceImpl()
        {
            connection = DBConnUtil.GetConnection();
        }

        public bool AddUser(User user)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            string query = "INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            if (connection.State != ConnectionState.Open)
                connection.Open();

            string query = "SELECT * FROM Users";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = reader["Role"].ToString()
                    });
                }
            }

            return users;
        }

        public bool Login(string username, string password)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public User GetUserByUsername(string username)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            string query = "SELECT * FROM Users WHERE Username = @username";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserId = Convert.ToInt32(reader["UserId"]),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                }
            }

            return null;
        }

        public bool DeleteUser(int userId)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            string query = "DELETE FROM Users WHERE UserId = @id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", userId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
