using System.ComponentModel.DataAnnotations.Schema;

namespace Bills_System.Models
{
	public class CompanyTypes
	{
		[ForeignKey("Type")]
		public int TypeId { get; set; }
		public virtual Type Type { get; set; }
		[ForeignKey("Company")]
		public int CompanyId { get; set; }
		public virtual Company Company { get; set; }
	}
}
