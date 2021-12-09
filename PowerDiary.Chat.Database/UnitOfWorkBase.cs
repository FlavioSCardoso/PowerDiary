using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace PowerDiary.Infrastructure.Database
{
	public abstract class UnitOfWorkBase :IUnitOfWork
	{
		private IDbContextTransaction transaction;

		public UnitOfWorkBase(DbContext context)
		{
			DbContext = context ?? throw new ArgumentNullException(nameof(context));
		}

		public DbContext DbContext { get; private set; }

		public async Task BeginTransactionAsync()
		{
			this.transaction = await DbContext.Database.BeginTransactionAsync();
		}

		public async Task RollBackAsync()
		{
			if (this.transaction == null)
				throw new Exception("Transaction not initialized");
			await this.transaction.RollbackAsync();
		}

		public async Task<int> SaveChangesAsync() => await DbContext.SaveChangesAsync();
	}
}
