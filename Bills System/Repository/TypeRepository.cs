using Bills_System.Data;
using Bills_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bills_System.Repository
{
	public class TypeRepository : ITypeRepository
	{
		private readonly ApplicationDBContext _context;

		public TypeRepository(ApplicationDBContext context)
		{
			_context = context;
		}
		public int Add(Type newType)
		{
			_context.Types.Add(newType);
			return _context.SaveChanges();
		}

		public int Delete(int id)
		{
			_context.Types.Remove(GetById(id));
			return _context.SaveChanges();
		}

		public List<Type> GetAll()
		{
			return _context.Types.ToList();
		}

		public Type GetById(int id)
		{
			return _context.Types.FirstOrDefault(c => c.Id == id);
			
		}

		public Type GetByName(string Name)
		{
			return _context.Types.Include(t=>t.Companies).FirstOrDefault(c => c.Name.ToLower() == Name);
		}



		public int Update(int id, Type newType)
		{
			
			var entry = _context.Entry(newType);
			entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			return _context.SaveChanges();
		}
	}
}
