using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PowerDiary.Infrastructure.Database
{
	public interface IUnitOfWork
	{
		DbContext DbContext { get; }

		Task BeginTransactionAsync();
		Task RollBackAsync();

		Task<int> SaveChangesAsync();
	}
}