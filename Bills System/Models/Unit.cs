using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bills_System.Models
{
	public class Unit
	{
		[Key]
		public int unit_id { set; get; }
		[MaxLength(50)]
		[Required(ErrorMessage ="Unit name is required")]
		//[UNIT NAME has already existed before”.]
		public string unit_name { set; get; }
		
		public string notes { set; get; }
		

	}
}
