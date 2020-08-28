using System;
using System.Threading;
namespace AQWConnect
{
    /// <summary>
    /// Message framework class for sending message packets to the AQW Client
    /// </summary>
    public class AQMessage
    {
        /// <summary>
        /// Function to send a message to the AQW Client
        /// </summary>
        /// <param name="Message"></param>
        /// Your message as a string
        /// <param name="Region"></param>
        /// The region for the message, zone/party/guild
        public static void Send(string Message, string Region)
        {
            if (Message.Length > 150)
            {
                int NoOfMessages = (int)Math.Ceiling((double)(Message.Length / 150.0));
                for (int i = 0; i < NoOfMessages; i++)
                {
                    if (Message.Length > (i + 1) * 149)
                        Message = Message.Insert((i + 1) * 149, "-");
                    string SplitMessage;
                    if (i == 0)
                        SplitMessage = Message.Substring(0, 150);
                    else SplitMessage = Message.Substring(i * 150, Message.Length - (i * 150));
                    string XtMessage = $"%xt%zm%message%1%{SplitMessage}%{Region}%";
                    AQClient.Call("SendPacket", new string[] { XtMessage });
                    Thread.Sleep(500);
                }
            }
            else
            {
                string XtMessage = $"%xt%zm%message%1%{Message}%{Region}%";
                AQClient.Call("SendPacket", new string[] { XtMessage });
            }
        }

        /// <summary>
        /// Function to send a whisper to a recipient
        /// </summary>
        /// <param name="Message"></param>
        /// Your message as a string
        /// <param name="Reciever"></param>
        /// Username of Reciever
        public static void SendDM(string Message, string Reciever)
        {
            if (Message.Length > 150)
            {
                int NoOfMessages = (int)Math.Ceiling((double)(Message.Length / 150.0));
                for (int i = 0; i < NoOfMessages; i++)
                {
                    if (Message.Length > (i + 1) * 149)
                        Message = Message.Insert((i + 1) * 149, "-");
                    string SplitMessage;
                    if (i == 0)
                        SplitMessage = Message.Substring(0, 150);
                    else SplitMessage = Message.Substring(i * 150, Message.Length - (i * 150));
                    string XtMessage = $"%xt%zm%whisper%1%{SplitMessage}%{Reciever}%";
                    AQClient.Call("SendPacket", new string[] { XtMessage });
                    Thread.Sleep(500);
                }
            }
            else
            {
                string XtMessage = $"%xt%zm%whisper%1%{Message}%{Reciever}%";
                AQClient.Call("SendPacket", new string[] { XtMessage });
            }
        }

        /// <summary>
        /// XML decodes the AQW Packet String
        /// </summary>
        /// <param name="XMLEncoded"></param>
        /// <returns></returns>
        public static string XMLDecode(string XMLEncoded)
        {
            return XMLEncoded.Replace("#060:", "<").Replace("#062:", ">").Replace("#038:", "&").Replace("#037:", "%");
        }

        /// <summary>
        /// XML encodes the regular message
        /// </summary>
        /// <param name="XMLDecoded"></param>
        /// <returns></returns>
        public static string XMLEncode(string XMLDecoded)
        {
            return XMLDecoded.Replace("<", "#060:").Replace(">", "#062:").Replace("&", "#038:").Replace("%", "#037:").Replace("“", "\"").Replace("”", "\"").Replace("‘", "\'").Replace("’", "\'");
        }
    }
}
