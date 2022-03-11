using Bills_System.Models;

namespace Bills_System.Repository
{
	public interface ICompanyRepository:IRepository<Company>
	{
		Company GetByName(string Name);

	}
}
