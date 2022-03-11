using Bills_System.Data;
using Bills_System.Models;
using System.Collections.Generic;
using System.Linq;
namespace Bills_System.Repository
{
    public class UnitRepositry:IunitRepositroy
    {
        public readonly ApplicationDBContext context;
        public UnitRepositry(ApplicationDBContext _context)
        {
            context = _context;
        }

        public int Add(Unit newunit)
        {
            context.Units.Add(newunit)
             ;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Unit> GetAll()
        {
            return context.Units.ToList();
                }

        public Unit GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Update(int id, Unit newT)
        {
            throw new System.NotImplementedException();
        }
    }
}
