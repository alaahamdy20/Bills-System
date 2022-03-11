using Bills_System.Data;
using Bills_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bills_System.Repository
{
	public class CompanyRepository : ICompanyRepository
	{
		private readonly ApplicationDBContext _context;

		public CompanyRepository(ApplicationDBContext context)
		{
			_context = context;
		}
		public int Add(Company newCompany)
		{
			_context.Companies.Add(newCompany);
			return _context.SaveChanges();
		}

		public int Delete(int id)
		{
			_context.Companies.Remove(GetById(id));
			return _context.SaveChanges();
		}

		public List<Company> GetAll()
		{
			return _context.Companies.ToList();
		}

		public Company GetById(int id)
		{
			return _context.Companies.FirstOrDefault(c => c.Id == id);
			
		}

		public Company GetByName(string Name)
		{
			return _context.Companies.Include(c => c.Types).FirstOrDefault(c => c.Name.ToLower() == Name);

		}

		public int Update(int id, Company newCompany)
		{
			
			var entry = _context.Entry(newCompany);
			entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			return _context.SaveChanges();
		}
	}
}
