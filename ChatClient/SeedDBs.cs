using Microsoft.EntityFrameworkCore;
using PowerDiary.BoundedContexts.BaseRegistry.Models;
using PowerDiary.BoundedContexts.BaseRegistry.Persistence;
using PowerDiary.BoundedContexts.Messaging.Chats.Models;
using PowerDiary.BoundedContexts.Messaging.Chats.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatClient
{
	public class SeedDBs
	{
		private readonly BaseRegistryContext baseRegistryContext;
		private readonly ChatsContext chatsContext;

		public SeedDBs(BaseRegistryContext baseRegistryContext, ChatsContext chatsContext)
		{
			this.baseRegistryContext = baseRegistryContext ?? throw new ArgumentNullException(nameof(baseRegistryContext));
			this.chatsContext = chatsContext ?? throw new ArgumentNullException(nameof(chatsContext));
		}

		/// <summary>
		/// Hey, IMPORTANT! We are calling this just for this project, ok? Seeding won't be done here
		/// </summary>
		/// <returns></returns>
		public async Task SeedEmAll() //yeah \m/
		{
			await chatsContext.Database.EnsureCreatedAsync(CancellationToken.None);
			await baseRegistryContext.Database.EnsureCreatedAsync(CancellationToken.None);

			await baseRegistryContext.Users.AddRangeAsync(new List<User>() {
				new User() { EmailAddress = "onefake@mail.com", InsertDate = DateTime.Now, Name = "Name One", UpdateDate = DateTime.Now },
				new User() { EmailAddress = "twofake@mail.com", InsertDate = DateTime.Now, Name = "Name Two", UpdateDate = DateTime.Now },
				new User() { EmailAddress = "threefake@mail.com", InsertDate = DateTime.Now, Name = "Name Three", UpdateDate = DateTime.Now },
				new User() { EmailAddress = "fourfake@mail.com", InsertDate = DateTime.Now, Name = "Name Four", UpdateDate = DateTime.Now },
				new User() { EmailAddress = "fivefake@mail.com", InsertDate = DateTime.Now, Name = "Name Five", UpdateDate = DateTime.Now },
			});

			await baseRegistryContext.SaveChangesAsync();

			var users = await baseRegistryContext.Users.AsNoTracking().ToListAsync();

			int min = users.Min(i => i.Id);
			int max = users.Min(i => i.Id);
			var random = new Random();
			var randomMinutes = new Random();

			var messages = users.Select(u => new Message()
			{
				EventType = PowerDiary.BoundedContexts.Messaging.Chats.MessageEvent.EnterTheRoom,
				SenderUserId = u.Id,
				InsertDate = DateTime.Now.AddMinutes(-10 + u.Id),
				UpdateDate = DateTime.Now.AddMinutes(-10 + u.Id)
			}).ToList();

			messages.AddRange(new List<Message>()
				{
					new Message()
					{
						Content = "this is a message content One",
						SenderUserId = random.Next(min, max),
						InsertDate = DateTime.Now.AddMinutes(-10 + randomMinutes.Next(-10, 10)),
						EventType = PowerDiary.BoundedContexts.Messaging.Chats.MessageEvent.Comment
					},
					new Message()
					{
						Content = "this is a message content Two",
						SenderUserId = random.Next(min, max),
						InsertDate = DateTime.Now.AddMinutes(-10 + randomMinutes.Next(-10, 10)),
						EventType = PowerDiary.BoundedContexts.Messaging.Chats.MessageEvent.Comment
					},
					new Message()
					{
						Content = "this is a message content Three",
						SenderUserId = random.Next(min, max),
						InsertDate = DateTime.Now.AddMinutes(-10 + randomMinutes.Next(-10, 10)),
						EventType = PowerDiary.BoundedContexts.Messaging.Chats.MessageEvent.Comment
					},
					new Message()
					{
						Content = "this is a message content Three",
						SenderUserId = random.Next(min, max),
						InsertDate = DateTime.Now.AddMinutes(-10 + randomMinutes.Next(-10, 10)),
						EventType = PowerDiary.BoundedContexts.Messaging.Chats.MessageEvent.LeaveTheRoom
					},
					new Message()
					{
						Content = users[random.Next(min, max) - 1].Name,
						SenderUserId = random.Next(min, max),
						InsertDate = DateTime.Now.AddMinutes(-10 + randomMinutes.Next(-10, 10)),
						EventType = PowerDiary.BoundedContexts.Messaging.Chats.MessageEvent.HightFileAnotherUser
					},new Message()
					{
						SenderUserId = random.Next(min, max),
						InsertDate = DateTime.Now.AddMinutes(-10 + randomMinutes.Next(-10, 10)),
						EventType = PowerDiary.BoundedContexts.Messaging.Chats.MessageEvent.LeaveTheRoom
					},
				});

			var chats = new List<Chat>()
			{
				new Chat() { InsertDate = DateTime.Now, Title = "Yeah, new chat!", Messages = messages }
			};

			await chatsContext.AddRangeAsync(chats);
			await chatsContext.SaveChangesAsync();
		}
	}
}
