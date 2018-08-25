using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Data
{
    public interface IRepository <T>
    {
        T GetById(int id);

        void UpSertEntity(T entity);

        T GetBy(string number);

        List<T> GetAllBy(string criteria);
    }
}
