using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PowerDiary.Infrastructure.Database
{
	public class Repository<T> : IRepository<T> where T : ModelBase, new()
	{
		protected readonly DbSet<T> _entities;

		public IUnitOfWork MyProperty { get; set; }

		public Repository(IUnitOfWork uow)
		{
			this._entities = uow.DbContext?.Set<T>() ?? throw new ArgumentNullException(nameof(uow));
		}

		public async Task AddAsync(T model) => await _entities.AddAsync(model);

		public async Task AddRangeAsync(IEnumerable<T> models) => await _entities.AddRangeAsync(models); 

		public void Delete(T model) => _entities.Remove(model); 

		public void DeleteRange(IEnumerable<T> models) => _entities.RemoveRange(models);

		public async ValueTask<T> FindAsync(object[] keys) => await _entities.FindAsync(keys);

		public async Task<IEnumerable<T>> GetAll() => await _entities.ToListAsync();

		public async Task<IEnumerable<T>> GetAllAsync() => await _entities.ToListAsync();

		public async ValueTask<T> GetByIdAsync(int id) => await _entities.FirstOrDefaultAsync(s => s.Id == id);

		public void UpdateRange(IEnumerable<T> models) => _entities.UpdateRange(models);

		public void Update(T model) => _entities.Update(model);

		public async ValueTask<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> predicate) => await _entities.Where(predicate).ToListAsync();

	}
}
