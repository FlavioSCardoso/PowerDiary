using PowerDiary.BoundedContexts.Messaging.Chats.Models;
using PowerDiary.BoundedContexts.Messaging.Chats.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Services
{
	public class MessagesServices : IMessagesServices
	{
		private readonly IMessageRepository messageRepository;

		public ChatsUnitOfWork UnitOfWork { get; }

		public MessagesServices(IMessageRepository messageRepository, ChatsUnitOfWork unitOfWork)
		{
			this.messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
			UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		public async Task<IEnumerable<Message>> GetAllMessages() => await messageRepository.GetAllAsync();

		public async ValueTask<Message> GetByIdAsync(int id) => await messageRepository.GetByIdAsync(id);

		public async ValueTask<Message> FindAsync(object[] keys) => await messageRepository.FindAsync(keys);
		public async Task AddAsync(Message model) => await messageRepository.AddAsync(model);
		public async Task AddRangeAsync(IEnumerable<Message> models) => await messageRepository.AddRangeAsync(models);
		public void Update(Message model) => messageRepository.Update(model);
		public void UpdateRange(IEnumerable<Message> models) => messageRepository.UpdateRange(models);
		public void Delete(Message model) => messageRepository.Delete(model);
		public void DeleteRange(IEnumerable<Message> models) => messageRepository.DeleteRange(models);
		public async ValueTask<IEnumerable<Message>> FindByDateRange(DateTime initial, DateTime final)
			 => await messageRepository.GetByFilterAsync(m => m.InsertDate >= initial && m.InsertDate <= final);

	}
}
