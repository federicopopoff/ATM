using Microsoft.EntityFrameworkCore;
using ATM.Model;
using System;

namespace ATM.Data
{
    public class ATMContext : DbContext
    {
        public ATMContext(DbContextOptions<ATMContext> options)
           : base(options)
        {
            this.CreateFirstDataAsync();
        }

        public ATMContext()
           : base()
        {
            this.CreateFirstDataAsync();
        }

        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Operation> Operations { get; set; }

        private void CreateFirstDataAsync()
        {
            var creditCardOne = new CreditCard
            {
                Attempts = 0,
                Balance = 1500,
                Blocked = false,
                Number = "1111111111111111",
                Pin = "1234"
            };

            var creditCardTwo = new CreditCard
            {
                Attempts = 0,
                Balance = 1500,
                Blocked = false,
                Number = "2222222222222222",
                Pin = "1234"
            };

            var operationOne = new Operation
            {
                Code = OperationTypeEnum.Balance,
                CreditCard = creditCardOne,
                CreditCardId = 1,
                Detail = "Balance",
                Time = DateTime.Now
            };

            var operationTwo = new Operation
            {
                Code = OperationTypeEnum.Balance,
                CreditCard = creditCardOne,
                CreditCardId = 1,
                Detail = "Balance",
                Time = DateTime.Now
            };

            var operationThree = new Operation
            {
                Code = OperationTypeEnum.WithDrawal,
                CreditCard = creditCardOne,
                CreditCardId = 1,
                Detail = "Withdrawal of 100",
                Time = DateTime.Now
            };

            this.CreditCards.Add(creditCardOne);
            this.CreditCards.Add(creditCardTwo);
            this.Operations.Add(operationOne);
            this.Operations.Add(operationTwo);
            this.Operations.Add(operationThree);

            this.SaveChanges();
        }

    }
}
