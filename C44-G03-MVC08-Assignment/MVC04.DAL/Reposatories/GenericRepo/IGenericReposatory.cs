using MVC04.DAL.Models.Employee;
using MVC04.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.DAL.Reposatories.GenericRepo
{
    public interface IGenericReposatory<T> where T : BaseEntity
    {
        public IQueryable<T> GetAll(bool WithTracking = false);
        public T GetById(int? id);
        public void Add(T item);
        public void Update(T item);
        public void Delete(int id);
    }
}
