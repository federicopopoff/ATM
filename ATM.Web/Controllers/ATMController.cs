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
        private readonly OperationService _operationService;

        public ATMController(IService<CreditCard> ccService, OperationService operationService)
        {
            this._ccService = ccService;
            this._operationService = operationService;
        }

        public IActionResult Home(int creditCardId)
        {
            ViewBag.CreditCardId = creditCardId;
            ViewBag.IsLogged = true;
            var operations = this._operationService.GetAllBy(creditCardId.ToString());
            return View(operations);
        }

        public IActionResult Balance(int creditCardId)
        {
            ViewBag.CreditCardId = creditCardId;
            ViewBag.IsLogged = true;
            this._operationService.InsertBalance(creditCardId);
            var creditCard = this._ccService.GetById(creditCardId);
            return PartialView("_Balance", creditCard);
        }

        public IActionResult WithDrawal(int creditCardId)
        {
            ViewBag.IsLogged = true;
            ViewBag.CreditCardId = creditCardId;
            return PartialView("_WithDrawal");
        }

        [HttpPost]
        public IActionResult WithDrawal(int creditCardId, int amount)
        {
            ViewBag.IsLogged = true;
            ViewBag.CreditCardId = creditCardId;
            try
            {
                this._operationService.InsertWithDrawal(creditCardId, amount);
                return PartialView("_WithDrawal");
            }
            catch (ATMNotCreditException ex)
            {
                return RedirectToActionPermanent("Error", "Login", new { reason = ex.Message });
            }
        }

        public ActionResult Exit()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}