using System;
using System.IO;
using Wpf.Ui.Controls;

namespace ME2Launcher.Services
{
    public static class Logger
    {
        private static readonly string LogFilePath = @"C:\Users\Equin\Dev\ME2Launcher\ME2Launcher\app.log";

        public static void ShowMessageBox(string content, string title)
        {
            var box = new MessageBox();
            box.Content = content;
            box.Title = title;
            box.CloseButtonText = "OK";
            box.IsPrimaryButtonEnabled = false;
            box.ShowDialogAsync();
        }

        public static void ClearLog()
        {
            if (File.Exists(LogFilePath))
            {
                File.Delete(LogFilePath);
            }
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath) ?? string.Empty);
                File.Create(LogFilePath).Dispose();
            }
        }

        public static void Info(string message)
        {
            Log($"[INFO] {message}");
        }

        public static void Error(string message)
        {
            Log($"[ERROR] {message}");
        }

        public static void Warn(string message)
        {
            Log($"[WARN] {message}");
        }

        public static void Log(string message)
        {
            var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(LogFilePath, line + Environment.NewLine);
        }

        public static void LogException(Exception ex, string context = "")
        {
            Log($"[ERROR] {context} {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
        }
    }
}
