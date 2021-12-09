using PowerDiary.BoundedContexts.BaseRegistry.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PowerDiary.BoundedContexts.BaseRegistry.Services
{
	public interface IUsersServices
	{
		Task AddAsync(User model);
		Task AddRangeAsync(IEnumerable<User> models);
		void Delete(User model);
		void DeleteRange(IEnumerable<User> models);
		ValueTask<User> FindAsync(object[] keys);
		ValueTask<IEnumerable<User>> FindByDateRange(DateTime initial, DateTime final);
		Task<IEnumerable<User>> GetAllUsers();
		ValueTask<User> GetByIdAsync(int id);
		void Update(User model);
		void UpdateRange(IEnumerable<User> models);
		ValueTask<IEnumerable<User>> GetByFilterAsync(Expression<Func<User, bool>> predicate);
	}
}