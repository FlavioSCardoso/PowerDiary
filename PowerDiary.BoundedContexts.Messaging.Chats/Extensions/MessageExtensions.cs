using PowerDiary.BoundedContexts.Messaging.Chats.Models;
using System;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Extensions
{
	public static class MessageExtensions
	{
		public static string VisualizeEvent(this Message message, string userName)
		{
			return message.EventType switch
			{
				MessageEvent.Comment => $"{userName} comments: \"{message.Content}\"",
				MessageEvent.EnterTheRoom => $"{userName} enters the room",
				MessageEvent.HightFileAnotherUser => $"{userName} high-fives {message.Content}",
				MessageEvent.LeaveTheRoom => $"{userName} leaves the room",
				_ => throw new Exception("Unrecognized Event")
			};
		}


	}
}
