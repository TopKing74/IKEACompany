using MVC04.DAL.Contexts;
using MVC04.DAL.Models.Department;
using MVC04.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.DAL.Reposatories.GenericRepo
{
    public class GenericReposatory<T> : IGenericReposatory<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public GenericReposatory(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(int id)
        {
            var t = _context.Set<T>().Find(id);
            if (t != null)
            {
                t.IsDeleted = true;
                _context.Set<T>().Update(t);
            }
        }

        public IQueryable<T> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return _context.Set<T>().Where(d => d.IsDeleted == false);
            }
            else
            {
                return _context.Set<T>().Where(d => d.IsDeleted == false).AsNoTracking();
            }
        }

        public T GetById(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }
}
