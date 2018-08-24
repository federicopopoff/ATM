using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM.Model;
using ATM.Model.Exception;
using ATM.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Web.Controllers
{
    public class ATMController : Controller
    {

        private readonly IService<CreditCard> _ccService;

        public ATMController(IService<CreditCard> ccService)
        {
            this._ccService = ccService;
            //this._operationService = operationService;
        }

        public ActionResult Exit()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}