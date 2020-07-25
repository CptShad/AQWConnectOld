using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AQWConnect
{
    public partial class AQClient : Form
    {
#if TESTING
        public Controls ControlsForm = new Controls();
#endif
        public Settings SettingsForm = new Settings();

        static bool FirstClick = true;
        public static AQClient Instance
        {
            get;
            private set;
        }
        public AQClient()
        {
            InitializeComponent();
#if TESTING
            ControlsForm.Show();
#endif
            Instance = this;
        }

        private void PackeBot_Load(object sender, EventArgs e)
        {
            byte[] array = Properties.Resources.AQWConnect;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write(8 + array.Length);
                    binaryWriter.Write(1432769894);
                    binaryWriter.Write(array.Length);
                    binaryWriter.Write(array);
                    memoryStream.Seek(0L, SeekOrigin.Begin);
                    flashPlayer.OcxState = new AxHost.State(memoryStream, 1, false, null);
                }
            }
        }

        private void flashPlayer_FlashCall(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent e)
        {
            XElement xelement = XElement.Parse(e.request);
            string value = xelement.Attribute("name").Value;
            if (xelement.HasAttributes && xelement.Attribute("name").Value == "packet")
            {
#if TESTING
                System.Console.WriteLine("[RECIEVED] : " + xelement.Element("arguments").Value);
#endif
                if (AQWConnect.discord != null)
                    AQWConnect.discord.Analyse(xelement.Element("arguments").Value);
            }


        }
		public static string Call(string function)
		{
			try
			{

				string request = $"<invoke name=\"{function}\" returntype=\"xml\"></invoke>";
				string response = "";
				response = XElement.Parse(Instance.flashPlayer.CallFunction(request)).FirstNode?.ToString();
				if (response == null)
				{
					return "";
				}
				return response;
			}
			catch (Exception e)
			{
				//DebugCallException(e, function);
				return "";
			}
		}

		public static string Call(string function, string[] args)
		{
			try
			{
				string request = $"<invoke name=\"{function}\" returntype=\"xml\"><arguments>";
				foreach (string arg in args)
					request += $"<string>{arg}</string>";
				request += "</arguments></invoke>";
				string response = "";
				response = XElement.Parse(Instance.flashPlayer.CallFunction(request)).FirstNode?.ToString();	
				if (response == null)
				{
					return string.Empty;
				}
				return response;
			}
			catch (Exception e)
			{
				//DebugCallException(e, function);
				return "";
			}
		}

        private void connectDiscordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ThisButton = (ToolStripMenuItem)sender;
            if (AQWConnect.discord == null)
            {
                Task.Factory.StartNew(AQWConnect.InitializeDiscordClient, TaskCreationOptions.RunContinuationsAsynchronously);
                return;
            }
            else
            {
                if (ThisButton.Text == "Connect Discord")
                {
                    ThisButton.Text = "Disconnect Discord";
                    AQWConnect.discord.IsLogging = true;
                    if (FirstClick)
                    {
                        string message = "Discord Connected.";
                        if (DiscordRPC.RPCConnected)
                            message = $"Discord Connected, Welcome {DiscordRPC.RPCConnectedTo}";
                        MessageBox.Show(message, "AQW Connect");
                        FirstClick = false;
                    }
                }
                else
                {
                    ThisButton.Text = "Connect Discord";
                    AQWConnect.discord.IsLogging = false;
                }
            }
        }

        private void donateToSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.me/captainshad/");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/CptShad/AQWConnectReleases/blob/master/README.md");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm.ShowDialog();
        }
    }
}
