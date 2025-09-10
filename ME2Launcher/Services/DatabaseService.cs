using System;
using Microsoft.Data.Sqlite;

namespace ME2Launcher.Services
{
    public static class DatabaseService
    {
        public static string DbFilePath = @"Core\Data.db";
        public static SqliteConnection Connection = new SqliteConnection($"DataSource={DbFilePath}");

        public static void InitializeDb()
        {
            Connection.Open();
            string query = @"
                CREATE TABLE IF NOT EXISTS Profiles (
                    Id TEXT PRIMARY KEY,
                    Name TEXT NOT NULL,
                    Description TEXT,
                    Mods TEXT,
                    Dll TEXT
                );
                CREATE TABLE IF NOT EXISTS Mods (
                    Id TEXT PRIMARY KEY,
                    Name TEXT NOT NULL,
                    Description TEXT,
                    FilePath TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Dlls (
                    Id TEXT PRIMARY KEY,
                    Name TEXT NOT NULL,
                    Description TEXT,
                    FilePath TEXT NOT NULL
                );";
            SqliteCommand command = new SqliteCommand(query, Connection);
            command.ExecuteNonQuery();
        }


    }
}
