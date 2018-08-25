using ATM.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Service
{
    public interface IOperationService : IService<Operation>
    {
        void InsertWithDrawal(int creditCardId, int amount);
        void InsertBalance(int creditCardId);
    }
}
