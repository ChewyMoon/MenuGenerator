namespace MenuGenerator.Utility
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Windows;

    /// <summary>
    ///     Updates this program.
    /// </summary>
    internal class Updater
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Checks for updates.
        /// </summary>
        public static async void CheckForUpdates()
        {
            var request =
                WebRequest.Create(
                    "https://raw.githubusercontent.com/ChewyMoon/MenuGenerator/master/MenuGenerator/Properties/AssemblyInfo.cs");

            var response = await request.GetResponseAsync();
            var data = response.GetResponseStream();

            string version = null;

            if (data != null)
            {
                using (var sr = new StreamReader(data))
                {
                    version = sr.ReadToEnd();
                }
            }

            const string Pattern = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";

            if (version == null)
            {
                return;
            }

            var serverVersion = new Version(new Regex(Pattern).Match(version).Groups[0].Value);

            if (serverVersion <= Assembly.GetExecutingAssembly().GetName().Version)
            {
                return;
            }

            var result = MessageBox.Show(
                "An update is available! Would you like to download it?",
                "Update Available",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information);

            if (result == MessageBoxResult.Yes)
            {
                Process.Start("https://github.com/ChewyMoon/MenuGenerator/releases");
            }
        }

        #endregion
    }
}