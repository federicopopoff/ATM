using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Service
{
    public interface IService<T>
    {
        T GetById(int id);
    }
}
