using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bills_System.Models
{
	public class Company
	{
		public Company()
		{
			Types = new HashSet<Type>();
		}
		public int Id { get; set; }
		[Required(ErrorMessage = "COMPANY NAME is Required")]
		[Remote("IsNameAvailble", "Admin", ErrorMessage = "COMPANY NAME has already existed before.")]
		public string Name { get; set; }
		public string Notes { get; set; }

		public virtual ICollection<Type> Types { get; set; }

	}
}
