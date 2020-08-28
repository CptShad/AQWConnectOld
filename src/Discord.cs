using System;
using Discord;
using Discord.WebSocket;
using System.Linq;
using System.Threading.Tasks;

namespace AQWConnect
{
	/// <summary>
	/// Class to integrate a Discord Bot with the client
	/// </summary>
	class Discord
	{
		private string Token;
		public DiscordSocketClient Client;
		public bool IsReady = false;
		public bool IsLogging = false;
		public Discord(string Token)
		{
			this.Token = Token;
		}
		/// <summary>
		/// Initializes the Discord Bot
		/// </summary>
		/// <returns></returns>
		public async Task Initialize()
		{
			Client = new DiscordSocketClient();
			Client.MessageReceived += MessageReceived;
			await Client.LoginAsync(TokenType.Bot, Token);
			await Client.StartAsync();
#if TESTING
			Console.WriteLine("Discord Initialized");
#endif
			IsReady = true;
			// Block this task until the program is closed.
			await Task.Delay(-1);
		}
		/// <summary>
		/// Function that Catches MessageReceived Event from the Discord Bot
		/// </summary>
		/// <param name="Message"></param>
		/// <returns></returns>
		public async Task MessageReceived(SocketMessage Message)
		{
			if (!IsLogging)
				return;
			if (Message.Content.Contains("!msg ") && Message.Content.Contains(':'))
			{
				string message = Message.Content.Substring(Message.Content.IndexOf(':') + 1);
				string argument = Message.Content.Substring(5, Message.Content.IndexOf(':') - 5);
				if (Message.Content.IndexOf(':') > 10)
					argument = "zone";

				message = AQMessage.XMLDecode(message);
				AQMessage.Send(message, argument);
				return;
			}
			if (Message.Content.Contains("!msg "))
            {
				string message = "";
				message = AQMessage.XMLDecode(Message.Content.Substring(5));
				AQMessage.Send(message, "zone");
				return;
			}
			if (Message.Content.Contains("!DM "))
			{
				string message = Message.Content.Substring(Message.Content.IndexOf(':') + 1);
				string reciever = Message.Content.Substring(4, Message.Content.IndexOf(':') - 4);

				message = AQMessage.XMLDecode(message);
				AQMessage.SendDM(message, reciever);
				return;
			}
		}
		
		private void SendMessage(string Message, string Channel = "general")
		{
			var Guild = Client.Guilds.First();
			
			var Category = Guild.CategoryChannels.Where(category => category.Name.Equals("Game Chat", StringComparison.OrdinalIgnoreCase)).First();
			var ChannelbyName = Category.Channels.Where(_channel => _channel.Name == Channel).First() as ISocketMessageChannel;

			if (ChannelbyName != null)
				ChannelbyName.SendMessageAsync(Message);
		}
		/*
		 Guild :
		[RECIEVED] : %xt%zm%message%0%f%guild%
		[RECIEVED] : %xt%chatm%0%guild~f%captain shad%16755%0%0%, (len: 43)
		Party :
		[RECIEVED] : %xt%zm%message%32123%f%party%
		[RECIEVED] : %xt%chatm%32123%party~f%captain shad%16755%32123%0%, (len: 51)
		zone :
		[RECIEVED] : %xt%zm%message%48759%f%zone%
		[RECIEVED] : %xt%chatm%48759%zone~f%captain shad%16755%48759%0%, (len: 53)
		whisper :
		[Sending]
		[RECIEVED] : %xt%zm%whisper%1%f%ultimatous24%
		[RECIEVED] : %xt%whisper%-1%f%captain shad%ultimatous24%0%0%, (len: 47)
		[Recieving]
		[RECIEVED] : %xt%uotls%-1%ultimatous24%sp:8,tx:311,ty:460,strFrame:Enter%, (len: 60)
		[RECIEVED] : %xt%whisper%-1%f%ultimatous24%captain shad%0%0%, (len: 47)

		//%xt%server%-1%Server shutdown in 2 minutes! Please log out to save your progress!%
		 */
		/// <summary>
		/// Function that sends message to the discord server
		/// </summary>
		/// <param name="Message"></param>
		/// <param name="Sender"></param>
		public void SendDiscordMessage(string Message, string Sender, bool IsWhisper = false)
		{
			Message = AQMessage.XMLDecode(Message);
			if (IsWhisper && IsReady)
			{
				SendMessage($"[WHISPER  {Message.Split('%')[5]} -> {Message.Split('%')[6]}] : {Message.Split('%')[4]}", "whisper");
			}
			else if (Message.Split('~')[0].Contains("guild") && IsReady)
			{
				SendMessage($"[GUILD] {Sender}: {Message.Split('~')[1]}", "guild");
			}
			else if (Message.Split('~')[0].Contains("party") && IsReady)
			{
				SendMessage($"[PARTY] {Sender}: {Message.Split('~')[1]}", "party");
			}
			else if (Message.Split('~')[0].Contains("zone") && IsReady)
			{
				SendMessage($"[ZONE] {Sender}: {Message.Split('~')[1]}");
			}
		}
		
		/// <summary>
		/// Function that analyses chat packets
		/// </summary>
		/// <param name="Packet"></param>
		public void Analyse(string Packet)
		{
			if (!IsLogging)
				return;
			if (Packet.Contains("%xt%chat") || Packet.Contains("%xt%whisper"))
			{
				string Message = Packet.Split('%')[4];
				string Sender = Packet.Split('%')[5];
				if (Packet.Contains("%xt%whisper"))
				{
					SendDiscordMessage(Packet, Sender, true);
					return;
				}
				SendDiscordMessage(Message, Sender);
			}
		}
	}

}
