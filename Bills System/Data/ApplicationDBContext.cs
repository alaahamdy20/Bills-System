using Bills_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Bills_System.Data
{
	public class ApplicationDBContext:DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
		{
				
		}
		public DbSet<Company> Companies { get; set; }
		public DbSet<Type> Types { get; set; }
	}
}
