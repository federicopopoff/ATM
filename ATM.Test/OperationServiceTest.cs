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
        private Mock<IRepository<Operation>> _opRepository;
        private Mock<IRepository<CreditCard>> _ccRepository;

        [TestInitialize]
        public void Initialize()
        {
            this._opRepository = new Mock<IRepository<Operation>>();
            this._ccRepository = new Mock<IRepository<CreditCard>>();
        }

        [TestMethod]
        public void VerifyInsertBalanceCallToInsertOperationTest()
        {
            throw new System.NotImplementedException();
        }
    }
}
