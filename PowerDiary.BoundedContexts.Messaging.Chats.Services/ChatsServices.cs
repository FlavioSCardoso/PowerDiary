using PowerDiary.BoundedContexts.Messaging.Chats.Models;
using PowerDiary.BoundedContexts.Messaging.Chats.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Services
{
	public class ChatsServices : IChatsServices
	{
		private readonly IChatRepository chatRepository;

		public ChatsUnitOfWork UnitOfWork { get; }

		public ChatsServices(IChatRepository chatRepository, ChatsUnitOfWork unitOfWork)
		{
			this.chatRepository = chatRepository ?? throw new ArgumentNullException(nameof(chatRepository));
			UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		public async Task<IEnumerable<Chat>> GetAllChats() => await chatRepository.GetAllAsync();

		public async ValueTask<Chat> GetByIdAsync(int id) => await chatRepository.GetByIdAsync(id);

		public async ValueTask<Chat> FindAsync(object[] keys) => await chatRepository.FindAsync(keys);
		public async Task AddAsync(Chat model) => await chatRepository.AddAsync(model);
		public async Task AddRangeAsync(IEnumerable<Chat> models) => await chatRepository.AddRangeAsync(models);
		public void Update(Chat model) => chatRepository.Update(model);
		public void UpdateRange(IEnumerable<Chat> models) => chatRepository.UpdateRange(models);
		public void Delete(Chat model) => chatRepository.Delete(model);
		public void DeleteRange(IEnumerable<Chat> models) => chatRepository.DeleteRange(models);

	}
}
