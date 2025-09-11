using System;
using Microsoft.Data.Sqlite;
using ME2Launcher.Models;
using System.Security.RightsManagement;

namespace ME2Launcher.Services
{
    public static class DatabaseService
    {
        public static string DbFilePath = @"C:\Users\Equin\Dev\ME2Launcher\ME2Launcher\Core\Data.db";
        public static SqliteConnection Connection { get; set; }

        public static void InitializeDb()
        {
            Connection = new SqliteConnection($"DataSource={DbFilePath}");
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

        public static List<Profile> GetProfiles()
        {
            List<Profile> pfs = new List<Profile>();
            string query = "SELECT * FROM Profiles;";
            SqliteCommand command = new SqliteCommand(query, Connection);
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                Profile pf = new Profile
                {
                    Id = Guid.Parse(reader.GetString(0)),
                    Name = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    ModList = [],
                    DllMods = []
                };
                pfs.Add(pf);
            }
            return pfs;
        }

        public static List<Mod> GetMods()
        {
            List<Mod> mods = new List<Mod>();
            string query = "SELECT * FROM Mods;";
            SqliteCommand command = new SqliteCommand(query, Connection);
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Mod mod = new Mod
                {
                    Id = Guid.Parse(reader.GetString(0)),
                    Name = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    Path = reader.GetString(3)
                };
                mods.Add(mod);
            }
            return mods;
        }

        public static List<Dll> GetDllMods()
        {
            List<Dll> dlls = new List<Dll>();
            string query = "SELECT * FROM Dlls;";
            SqliteCommand command = new SqliteCommand(query, Connection);
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Dll dll = new Dll
                {
                    Id = Guid.Parse(reader.GetString(0)),
                    Name = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    FilePath = reader.GetString(3)
                };
                dlls.Add(dll);
            }
            return dlls;
        }
    
        public static void CreateNewProfile(Profile p)
        {
            const string query = @"
            INSERT INTO Profiles (Id, Name, Description, Mods, Dll)
            VALUES (@Id, @Name, @Description, @Mods, @Dll);";

            using var command = new SqliteCommand(query, Connection);
            command.Parameters.AddWithValue("@Id", p.Id.ToString());
            command.Parameters.AddWithValue("@Name", p.Name);
            command.Parameters.AddWithValue("@Description", p.Description ?? string.Empty);
            command.Parameters.AddWithValue("@Mods", string.Join(";", p.ModList.Select(m => m.Id.ToString())));
            command.Parameters.AddWithValue("@Dll", string.Join(";", p.DllMods.Select(d => d.Id.ToString())));

            command.ExecuteNonQuery();
        }

        public static void UpdateProfileById(Guid id, Profile new_profile)
        {
            string query = "UPDATE Profiles SET Name = @Name, Description = @Description, Mods = @Mods, Dll = @Dll WHERE Id = @Id;";
            SqliteCommand command = new SqliteCommand(query, Connection);
            command.Parameters.AddWithValue("@Id", id.ToString());
            command.Parameters.AddWithValue("@Name", new_profile.Name);
            command.Parameters.AddWithValue("@Description", new_profile.Description);
            command.Parameters.AddWithValue("@Mods", string.Join(";", new_profile.ModList.Select(m => m.Id.ToString())));
            command.Parameters.AddWithValue("@Dll", string.Join(";", new_profile.DllMods.Select(d => d.Id.ToString())));
            command.ExecuteNonQuery();
        }

        public static void CloseConnection()
        {
            Connection.Close();
        }
    }
}
