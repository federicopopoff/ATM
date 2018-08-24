using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Model.Exception
{
    public class ATMException : ApplicationException
    {
        public ATMException(string message) : base(message) { }
    }
}
