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

        public Operation GetBy(string creditCardId)
        {
            throw new NotImplementedException();
        }

        public List<Operation> GetAllBy(string criteria)
        {
            return this._context.Operations.Where(o => o.CreditCardId == int.Parse(criteria)).ToList();
        }

        public void UpSertEntity(Operation operation)
        {
            var operationSave = this.GetById(operation.Id);

            if (operationSave == null)
            {
                this._context.Operations.Add(operation);
            }

            this._context.SaveChanges();
        }

    }
}
