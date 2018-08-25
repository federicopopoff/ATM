using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Service
{
    public interface IService<T>
    {
        T GetById(int id);
        void UpSertEntity(T entity);
        bool Exists(string number);
        T GetByNumber(string number);
        T GetByParameters(string[] parameters);
        List<T> GetAllBy(string criteria);
    }
}
