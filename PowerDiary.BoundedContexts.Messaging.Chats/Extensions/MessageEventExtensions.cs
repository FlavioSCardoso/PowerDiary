using System;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Extensions
{
	public static class MessageEventExtensions
	{
		public static string GetEventName(this MessageEvent messageEvent)
		{
			return messageEvent switch
			{
				MessageEvent.Comment => "comments",
				MessageEvent.EnterTheRoom => "enters the room",
				MessageEvent.HightFileAnotherUser => "high-fives",
				MessageEvent.LeaveTheRoom => "leaves the room",
				_ => throw new Exception("Unrecognized Event")
			};
		}

		public static string MapEventToConstant(this MessageEvent messageEvent)
		{
			return messageEvent switch
			{
				MessageEvent.Comment => "comment",
				MessageEvent.EnterTheRoom => "enter-the-room",
				MessageEvent.HightFileAnotherUser => "high-five-another-user",
				MessageEvent.LeaveTheRoom => "leave-the-room",
				_ => throw new Exception("Unrecognized Event")
			};
		}

		public static MessageEvent MapConstantToEvent(this string messageEvent)
		{
			return messageEvent switch
			{
				"comment" => MessageEvent.Comment,
				"enter-the-room" => MessageEvent.EnterTheRoom,
				"high-five-another-user" => MessageEvent.HightFileAnotherUser,
				"leave-the-room" => MessageEvent.LeaveTheRoom,
				_ => throw new Exception("Invalid value")
			};
		}

	}
}
