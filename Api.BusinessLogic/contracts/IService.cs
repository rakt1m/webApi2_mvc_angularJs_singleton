using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.BusinessLogic.contracts
{
    public interface IService<TEntity> where TEntity : class
    {
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Remove(long id);
        TEntity Get(long id);
        IEnumerable<TEntity> GetAll();
    }
}
