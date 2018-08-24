using ATM.Data;
using ATM.Model;
using ATM.Model.Exception;
using System.Collections.Generic;
using System.Linq;

namespace ATM.Service
{
    public class CreditCardService : IService<CreditCard>
    {
        private readonly IRepository<CreditCard> _ccRepository;

        public CreditCardService(IRepository<CreditCard> ccRepository)
        {
            this._ccRepository = ccRepository;
        }

        public CreditCard GetById(int id)
        {
            return this._ccRepository.GetById(id);
        }
    }
}
