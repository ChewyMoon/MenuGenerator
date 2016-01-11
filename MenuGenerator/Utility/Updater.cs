namespace MenuGenerator.Utility
{
    using System;
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
        public static void CheckForUpdates()
        {
            var request =
                    WebRequest.Create(
                        "https://github.com/ChewyMoon/MenuGenerator/blob/master/MenuGenerator/Properties/AssemblyInfo.cs");
            var response = request.GetResponse();
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

            if (serverVersion > Assembly.GetExecutingAssembly().GetName().Version)
            {
                MessageBox.Show("There is a new version avaiable! Download at github.", "Update Available");
            }
        }

        #endregion
    }
}