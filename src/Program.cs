using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AQWConnect
{
    static class AQWConnect
    {
        public static Discord discord;
        public static async void InitializeDiscordClient()
        {
            string token = Config.GetToken();
            if (DiscordRPC.client == null)
                DiscordRPC.Initialize();
            if (token == "")
            {
#if TESTING
                Console.WriteLine("Discord token empty, Discord not Initialized.");
#endif
                MessageBox.Show("Discord token empty, Discord not Initialized.", "AQW Connect");
                return;
            }
            discord = new Discord(token);
            await discord.Initialize();
        }
            
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if TESTING
            Console.Initialize();
#endif
            Config.Initialize();
            Task.Factory.StartNew(InitializeDiscordClient, TaskCreationOptions.RunContinuationsAsynchronously);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AQClient());
#if TESTING
            Console.FreeConsole();
#endif
        }
    }
}
