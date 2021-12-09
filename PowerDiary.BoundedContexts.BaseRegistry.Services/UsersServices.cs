using PowerDiary.BoundedContexts.BaseRegistry.Models;
using PowerDiary.BoundedContexts.BaseRegistry.Persistence;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PowerDiary.BoundedContexts.BaseRegistry.Services
{
	public class UsersServices : IUsersServices
	{
		private readonly IUserRepository userRepository;

		public BaseRegistryUnitOfWork UnitOfWork { get; }

		public UsersServices(IUserRepository userRepository, BaseRegistryUnitOfWork unitOfWork)
		{
			this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
			UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		public async Task<IEnumerable<User>> GetAllUsers() => await userRepository.GetAllAsync();

		public async ValueTask<User> GetByIdAsync(int id) => await userRepository.GetByIdAsync(id);

		public async ValueTask<User> FindAsync(object[] keys) => await userRepository.FindAsync(keys);
		public async Task AddAsync(User model) => await userRepository.AddAsync(model);
		public async Task AddRangeAsync(IEnumerable<User> models) => await userRepository.AddRangeAsync(models);
		public void Update(User model) => userRepository.Update(model);
		public void UpdateRange(IEnumerable<User> models) => userRepository.UpdateRange(models);
		public void Delete(User model) => userRepository.Delete(model);
		public void DeleteRange(IEnumerable<User> models) => userRepository.DeleteRange(models);
		public async ValueTask<IEnumerable<User>> FindByDateRange(DateTime initial, DateTime final)
			 => await userRepository.GetByFilterAsync(m => m.InsertDate <= initial && m.InsertDate >= final);
		public async ValueTask<IEnumerable<User>> GetByFilterAsync(Expression<Func<User, bool>> predicate) => await userRepository.GetByFilterAsync(predicate);

	}
}
