using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Model.Exception
{
    public class ATMCardBlockedException : ApplicationException
    {
        public ATMCardBlockedException(string message) : base(message) { }
    }
}
