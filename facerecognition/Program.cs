using System;
using System.Windows.Forms;

namespace facerecognition
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Connection.ConfigureDatabase();
            RecognitionSingleton.Users = Connection.RetrieveUsers();
            Application.Run(new FormDetector());
        }
    }
}