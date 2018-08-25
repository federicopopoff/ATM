using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ATM.Data;
using ATM.Model;
using ATM.Model.Exception;
using ATM.Service;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ATM.Test
{
    [TestClass]
    public class OperationServiceTest
    {
        private OperationService _opService;
        private Mock<IRepository<Operation>> _opRepository;
        private Mock<IRepository<CreditCard>> _ccRepository;

        [TestInitialize]
        public void Initialize()
        {
            this._opRepository = new Mock<IRepository<Operation>>();
            this._ccRepository = new Mock<IRepository<CreditCard>>();
            this._opService = new OperationService(this._ccRepository.Object, this._opRepository.Object);

        }

        [TestMethod]
        public void VerifyInsertBalanceCallToInsertOperationTest()
        {
            this._opService.InsertBalance(1);

            this._opRepository.Verify(op => op.UpSertEntity(It.Is<Operation>(o => o.CreditCardId == 1)));
        }

        [TestMethod]
        public void GetMoreAmountThanTheUserHasTest()
        {
            var creditCard = new CreditCard
            {
                Id = 1,
                Balance = 250
            };

            this._ccRepository.Setup(cc => cc.GetById(1)).Returns(creditCard);

            Assert.ThrowsException<ATMNotCreditException>(() => this._opService.InsertWithDrawal(1, 2000));
        }

        [TestMethod]
        public void GetLessAmountThanBalanceTest()
        {
            var creditCard = new CreditCard
            {
                Id = 1,
                Balance = 250
            };

            this._ccRepository.Setup(cc => cc.GetById(1)).Returns(creditCard);

            this._opService.InsertWithDrawal(1, 20);

            this._ccRepository.Verify(op => op.UpSertEntity(It.Is<CreditCard>(o => o.Balance == 230)));
        }
    }
}
