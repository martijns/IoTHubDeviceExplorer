using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using MsCommon.ClickOnce;

namespace DeviceExplorer.ClickOnce
{
    static class Program
    {
        private static ILog Logger = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arguments)
        {
            Action<string[]> method = (args) =>
            {
                XmlConfigurator.Configure();
                Logger.Info("Starting...");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                AppVersion.CheckForUpdateAsync().ContinueWith((task, state) => { Logger.Error("Error while checking for update", task.Exception); }, null, TaskContinuationOptions.OnlyOnFaulted).ConfigureAwait(false);

                var form = new MainForm();
                Application.Run(form);
            };

            AppProgram.Start(
                applicationName: "IoTHubDeviceExplorer",
                authorName: "Martijn Stolk",
                reportBugEndpoint: "http://martijn.tikkie.net/reportbug.php",
                feedbackEndpoint: "http://martijn.tikkie.net/feedback.php",
                args: arguments,
                mainMethod: method);
        }
    }
}
