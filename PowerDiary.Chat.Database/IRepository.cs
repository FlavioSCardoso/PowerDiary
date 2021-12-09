using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PowerDiary.Infrastructure.Database
{
	public interface IRepository<T> where T : ModelBase, new()
	{
		ValueTask<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> predicate);
		Task<IEnumerable<T>> GetAllAsync();
		ValueTask<T> GetByIdAsync(int id);
		ValueTask<T> FindAsync(object[] keys);
		Task AddAsync(T model);
		Task AddRangeAsync(IEnumerable<T> models);
		void Update(T model);
		void UpdateRange(IEnumerable<T> models);
		void Delete(T model);
		void DeleteRange(IEnumerable<T> models);

	}
}
