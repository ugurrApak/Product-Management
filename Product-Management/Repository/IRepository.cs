using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management.Repository
{
    internal interface IRepository<T>
    {
        bool Add(T entity);
        bool Delete(uint id);
        T GetValue(uint id);
        bool Update(T entity);
        bool Deactivate(uint id);
        List<T> GetAll();
    }
}
