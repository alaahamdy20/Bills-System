using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bills_System.Models
{
	public class Client

	{
		
		public int Id { get; set; }
		[Required(ErrorMessage = "TYPE NAME is Required")]
		public string Name { get; set; }
		public string Address { get; set; }
		public int Number { get; set; }
		public string Phone { get; set; }
		public virtual Company Company { get; set; }

	}
}
