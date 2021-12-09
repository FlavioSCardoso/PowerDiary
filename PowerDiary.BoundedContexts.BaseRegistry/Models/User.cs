using PowerDiary.Infrastructure.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerDiary.BoundedContexts.BaseRegistry.Models
{
	[Table("Users")]
	public class User : ModelBase
	{
		public string Name { get; set; }
		public string EmailAddress { get; set; }
	}
}
