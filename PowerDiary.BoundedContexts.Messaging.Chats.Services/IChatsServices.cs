using PowerDiary.BoundedContexts.Messaging.Chats.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Services
{
	public interface IChatsServices
	{
		Task AddAsync(Chat model);
		Task AddRangeAsync(IEnumerable<Chat> models);
		void Delete(Chat model);
		void DeleteRange(IEnumerable<Chat> models);
		ValueTask<Chat> FindAsync(object[] keys);
		Task<IEnumerable<Chat>> GetAllChats();
		ValueTask<Chat> GetByIdAsync(int id);
		void Update(Chat model);
		void UpdateRange(IEnumerable<Chat> models);
	}
}