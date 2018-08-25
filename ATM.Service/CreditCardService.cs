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

        public bool Exists(string number)
        {
            return this.GetByNumber(number) != null;
        }

        public void UpSertEntity(CreditCard entity)
        {
            this._ccRepository.UpSertEntity(entity);
        }

        public CreditCard GetByParameters(string[] parameters)
        {
            var creditCardNumber = parameters[0];
            var pin = parameters[1];

            var creditCard = this.GetByNumber(creditCardNumber);

            if (creditCard.Pin == pin)
            {
                creditCard.Attempts = 0;
                this.UpSertEntity(creditCard);
                return creditCard;
            }

            creditCard.Attempts = creditCard.Attempts + 1;

            if (creditCard.Attempts == 4)
            {
                creditCard.Blocked = true;
                this.UpSertEntity(creditCard);
                throw new ATMCardBlockedException("The credit card has been blocked.");
            }

            this.UpSertEntity(creditCard);
            throw new ATMException("The pin entered is Incorrect.");
        }

        public CreditCard GetByNumber(string number)
        {
            var creditCard = this._ccRepository.GetBy(number);

            if (creditCard == null)
            {
                throw new ATMException("That Credit Card does not exist");
            }
            if (creditCard.Blocked)
            {
                throw new ATMException("Credit Card is currently Blocked");
            }

            return creditCard;
        }

        public List<CreditCard> GetAllBy(string criteria)
        {
            throw new System.NotImplementedException();
        }

    }
}
