using GitConfigManager.Models;

namespace GitConfigManager;

using Microsoft.Data.Sqlite;
using System.Collections.Generic;

public class SQLiteUserRepository : IUserRepository
{
    private readonly string _connectionString;

    public SQLiteUserRepository(string databasePath)
    {
        _connectionString = $"Data Source={databasePath}";
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Email TEXT NOT NULL
                );
            ";
            command.ExecuteNonQuery();
        }
    }

    public UserConfig GetUserById(string id)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name, Email FROM Users WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new UserConfig(
                        reader["Id"].ToString(),
                        reader["Name"].ToString(),
                        reader["Email"].ToString());
                }
            }
        }
        return null;
    }

    public void AddUser(UserConfig user)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Users (Name, Email)
                VALUES (@name, @Email);
            ";
            command.Parameters.AddWithValue("@name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.ExecuteNonQuery();
        }
    }

    public void RemoveUser(string id)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Users WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }

    public IEnumerable<UserConfig> GetAllUsers()
    {
        var users = new List<UserConfig>();

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name, Email FROM Users";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    users.Add(new UserConfig(
                        reader["Id"].ToString(),
                        reader["Name"].ToString(),
                        reader["Email"].ToString()));
                }
            }
        }
        return users;
    }
}
