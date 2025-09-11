using Microsoft.Data.Sqlite;
using System.Data;
using ME2Launcher.Models;

namespace ME2Launcher.Services
{
    public static class DatabaseService
    {
        public static string DbFilePath = @"C:\Users\Equin\Dev\ME2Launcher\ME2Launcher\Core\Data.db";
        public static SqliteConnection Connection { get; set; }

        public static void InitializeDb()
        {
            Logger.Info("Initializing DB connection at '" + DbFilePath + "'");
            Connection = new SqliteConnection($"DataSource={DbFilePath}");
            Connection.Open();
            Logger.Info("DB connection initialized and opened");

            Logger.Info("Performing DB post initialization");
            DbPostInitialize();
            Logger.Info("DB post initialization complete");
        }

        private static void DbPostInitialize()
        {
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Profiles ( Id TEXT PRIMARY KEY, Name TEXT NOT NULL, Description TEXT, Mods TEXT, Dll TEXT );");
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Mods ( Id TEXT PRIMARY KEY, Name TEXT NOT NULL, Description TEXT, FilePath TEXT NOT NULL );");
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Dlls ( Id TEXT PRIMARY KEY, Name TEXT NOT NULL, Description TEXT, FilePath TEXT NOT NULL );");
        }

        private static bool DbReadyToUse()
        {
            return Connection != null && Connection.State == ConnectionState.Open;
        }

        private static void ExecuteNonQuery(string query)
        {
            new SqliteCommand(query, Connection).ExecuteNonQuery();
        }

        public static List<Profile> GetProfiles()
        {
            List<Profile> pfs = new List<Profile>();
            if (!DbReadyToUse())
            {
                Logger.Warn("Could not get profiles from DB");
                return pfs;
            }
            var command = SqliteCommand("SELECT * FROM Profiles;");
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
            if (!DbReadyToUse())
            {
                Logger.Warn("Could not get mods from DB");
                return mods;
            }
            var command = SqliteCommand("SELECT * FROM Mods;");
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
            if (!DbReadyToUse())
            {
                Logger.Warn("Could not get dll mods from DB");
                return dlls;
            }
            var command = SqliteCommand("SELECT * FROM Dlls;");
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
    
        public static SqliteCommand SqliteCommand(string query)
        {
            return new SqliteCommand(query, Connection);
        }

        public static void CreateNewProfile(Profile p)
        {
            if (!DbReadyToUse())
            {
                Logger.Warn("Could not create new profile in DB");
                return;
            }
            using var command = SqliteCommand("INSERT INTO profiles VALUES (@Id,  @Name, @Description, @Mods, @Dll);");
            command.Parameters.AddWithValue("@Id", p.Id.ToString());
            command.Parameters.AddWithValue("@Name", p.Name);
            command.Parameters.AddWithValue("@Description", p.Description ?? string.Empty);
            command.Parameters.AddWithValue("@Mods", string.Join(";", p.ModList.Select(m => m.Id.ToString())));
            command.Parameters.AddWithValue("@Dll", string.Join(";", p.DllMods.Select(d => d.Id.ToString())));

            Logger.Info("Creating new Profile in DB");
            command.ExecuteNonQuery();
        }

        public static void UpdateProfileById(Guid id, Profile new_profile)
        {
            if (!DbReadyToUse())
            {
                Logger.Warn("Could not update profile in DB with ID: " + id);
                return;
            }
            using var command = SqliteCommand("UPDATE Profiles SET Name = @Name, Description = @Description, Mods = @Mods, Dll = @Dll WHERE Id = @Id;");
            command.Parameters.AddWithValue("@Id", id.ToString());
            command.Parameters.AddWithValue("@Name", new_profile.Name);
            command.Parameters.AddWithValue("@Description", new_profile.Description);
            command.Parameters.AddWithValue("@Mods", string.Join(";", new_profile.ModList.Select(m => m.Id.ToString())));
            command.Parameters.AddWithValue("@Dll", string.Join(";", new_profile.DllMods.Select(d => d.Id.ToString())));

            Logger.Info("Updating Profile in DB with ID: " + id);
            command.ExecuteNonQuery();
        }

        public static void CloseConnection()
        {
            Logger.Info("Closing DB connection");
            Connection.Close();
        }
    }
}
