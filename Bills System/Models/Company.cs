using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bills_System.Models
{
	public class Company
	{

		public int Id { get; set; }
		[Required(ErrorMessage = "COMPANY NAME is Required")]
		[Remote("IsAlreadyExisted", "Admin", ErrorMessage = "COMPANY NAME has already existed before.")]
		public string Name { get; set; }
		public string Notes { get; set; }

	}
}
