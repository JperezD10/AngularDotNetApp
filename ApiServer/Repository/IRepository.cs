using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T> where T : Entity
    {
        Task<IList<T>> GetAll();
        Task<T> GetAsync(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
