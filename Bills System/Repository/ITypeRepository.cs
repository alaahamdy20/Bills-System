using Bills_System.Models;

namespace Bills_System.Repository
{
	public interface ITypeRepository : IRepository<Type>
	{
		Type GetByName(string Name);

	}
}
