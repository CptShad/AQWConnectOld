using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AQWConnect
{
    public partial class Controls : Form
    {
        public Controls()
        {
            InitializeComponent();
        }

        private void ViewLogButton_Click(object sender, EventArgs e)
        {
            Button ThisButton = (Button)sender;
            if (ThisButton.Text == "View Packet Log")
            {
                ThisButton.Text = "Hide Packet Log";
#if TESTING
                Console.ShowConsole(true);
#endif
            }
            else
            {
                ThisButton.Text = "View Packet Log";
#if TESTING
                Console.ShowConsole(false);
#endif
            }
        }

        public void ConnectDiscordButton_Click(object sender, EventArgs e)
        {
            Button ThisButton = (Button)sender;
            if (AQWConnect.discord == null)
            {
                Task.Factory.StartNew(AQWConnect.InitializeDiscordClient, TaskCreationOptions.RunContinuationsAsynchronously);
                return;
            }
            if (ThisButton.Text == "Connect Discord")
            {
                ThisButton.Text = "Disconnect Discord";
                AQWConnect.discord.IsLogging = true;
            }
            else
            {
                ThisButton.Text = "Connect Discord";
                AQWConnect.discord.IsLogging = false;
            }
        }

        private void SendPacketButton_Click(object sender, EventArgs e)
        {
#if TESTING
            if (this.PacketField.Text != "")
                AQClient.Call("SendPacket", new string[] { this.PacketField.Text });
#endif
        }

        public void DonateButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.me/captainshad/");
        }
    }
}
