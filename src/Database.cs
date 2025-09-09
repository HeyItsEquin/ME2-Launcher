using System;
using Microsoft.Data.Sqlite;

namespace ME2Launcher
{
    public static class Database
    {
        public static string DbFilePath = @"Internal\Data.db";
        
        public static SqliteConnection? Connection;

        public static void InitializeDb()
        {
            Connection = new SqliteConnection($"DataSource={DbFilePath}");
            Connection.Open();

            string query =
            @"
                CREATE TABLE IF NOT EXISTS Profiles (
                    Id INT PRIMARY KEY,
                    Name TEXT NOT NULL,
                    Description TEXT,
                    Mods TEXT,
                    Dll TEXT
                );

                CREATE TABLE IF NOT EXISTS Mods (
                    Id INT PRIMARY KEY,
                    Name TEXT NOT NULL,
                    Description TEXT,
                    FilePath TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Dlls (
                    Id INT PRIMARY KEY,
                    Name TEXT NOT NULL,
                    Description TEXT,
                    FilePath TEXT NOT NULL
                );
            ";

            SqliteCommand command = new SqliteCommand(query, Connection);
            command.ExecuteNonQuery();
        }
    }
}