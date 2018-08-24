using ATM.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM.Data
{
    public class CreditCardRepository: IRepository<CreditCard>
    {
        private readonly ATMContext _context;

        public CreditCardRepository(ATMContext context)
        {
            this._context = context;
        }

        public CreditCard GetById(int id)
        {
            return this._context.CreditCards.FirstOrDefault(cc => cc.Id == id);
        }

    }
}
