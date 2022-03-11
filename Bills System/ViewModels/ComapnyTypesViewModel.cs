using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bills_System.ViewModels
{
	public class ComapnyTypesViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "TYPE NAME is Required")]
		[Remote("IsTypeExisted", "Admin", ErrorMessage = "TYPE NAME has already existed before.", AdditionalFields = "ComapnyName")]
		public string Name { get; set; }
		public string Notes { get; set; }
		[Required(ErrorMessage = "COMPANY NAME is Required")]
		public string ComapnyName { get; set; }

	}
}
