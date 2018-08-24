using ATM.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM.Data
{
    public class OperationRepository: IRepository<Operation>
    {
        private readonly ATMContext _context;

        public OperationRepository(ATMContext context)
        {
            this._context = context;
        }

        public Operation GetById(int id)
        {
            return this._context.Operations.FirstOrDefault(cc => cc.Id == id);
        }

    }
}
