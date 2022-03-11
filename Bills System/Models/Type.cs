using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bills_System.Models
{
	public class Type
	{
		
		public int Id { get; set; }
		[Required(ErrorMessage = "TYPE NAME is Required")]
		[Remote("IsTypeExisted", "Admin", ErrorMessage = "TYPE NAME has already existed before.",AdditionalFields ="id")]
		public string Name { get; set; }
		public string Notes { get; set; }
		public virtual Company Company { get; set; }

	}
}
