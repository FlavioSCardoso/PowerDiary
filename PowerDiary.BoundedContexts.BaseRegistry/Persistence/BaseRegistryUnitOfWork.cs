using PowerDiary.Infrastructure.Database;

namespace PowerDiary.BoundedContexts.BaseRegistry.Persistence
{
	public class BaseRegistryUnitOfWork : UnitOfWorkBase
	{
		public BaseRegistryUnitOfWork(BaseRegistryContext context) : base(context)
		{ }
	}
}
