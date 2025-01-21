using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutliShop.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetAll();
        T TGetById(int id);
        void TAdd(T entity);
        void TUpdate(T entity);
        void TDelete(int id);
    }
}
