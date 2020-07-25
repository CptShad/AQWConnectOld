using DiscordRPC;

namespace AQWConnect
{
    /// <summary>
    /// Class used for Discord Rich Presence
    /// </summary>
    public class DiscordRPC
    {
        public static DiscordRpcClient client;
        public static bool RPCConnected = false;
        public static string RPCConnectedTo = "";
        public static void Initialize()
        { 
            client = new DiscordRpcClient("456867456040960001");
            client.OnReady += (sender, msg) =>
            {
#if TESTING
                Console.WriteLine($"Connected Discord Rich Presence with user {msg.User.Username}");
#endif
                RPCConnected = true;
                RPCConnectedTo = msg.User.Username;
            };

            client.OnPresenceUpdate += (sender, msg) =>
            {
#if TESTING
                Console.WriteLine("Presence has been updated! ");
#endif
            };
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "Playing AQW",
                State = "By : CptShad#7140",
                Assets = new Assets()
                {
                    LargeImageKey = "icon",
                    LargeImageText = "AQW Connect"
                },
                Timestamps = Timestamps.Now
            });
        }
        public static void UpdatePresence(RichPresence richPresence)
        {
            client.SetPresence(richPresence);
        }
        public static void UpdatePresence(string details)
        {
            client.SetPresence(new RichPresence()
            {
                Details = details,
                State = "By : CptShad#7140",
                Assets = new Assets()
                {
                    LargeImageKey = "icon",
                    LargeImageText = "AQW Connect"
                }
            });
        }
    }
}
