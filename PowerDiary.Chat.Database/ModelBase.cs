using System;

namespace PowerDiary.Infrastructure.Database
{
	public abstract class ModelBase
	{
		public int Id { get; set; }
		public DateTime InsertDate { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}