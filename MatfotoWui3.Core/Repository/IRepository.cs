using System;
using System.Collections.Generic;
using System.Text;

namespace MatfotoWui3.Core.Repository
{
    public interface IRepository<T>
    {
        T Find(long id);

        void Insert(T entity);        
        
        void Update(T entity);

        void Delete(T entity);

        void Save();
    }
}
