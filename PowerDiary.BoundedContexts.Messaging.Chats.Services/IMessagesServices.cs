using PowerDiary.BoundedContexts.Messaging.Chats.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Services
{
	public interface IMessagesServices
	{
		Task AddAsync(Message model);
		Task AddRangeAsync(IEnumerable<Message> models);
		void Delete(Message model);
		void DeleteRange(IEnumerable<Message> models);
		ValueTask<Message> FindAsync(object[] keys);
		ValueTask<IEnumerable<Message>> FindByDateRange(DateTime initial, DateTime final);
		Task<IEnumerable<Message>> GetAllMessages();
		ValueTask<Message> GetByIdAsync(int id);
		void Update(Message model);
		void UpdateRange(IEnumerable<Message> models);
	}
}