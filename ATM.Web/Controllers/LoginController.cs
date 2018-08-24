using ATM.Model;
using ATM.Model.Exception;
using ATM.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ATM.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IService<CreditCard> _ccService;
        public LoginController(IService<CreditCard> ccService)
        {
            this._ccService = ccService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string creditCardNumber)
        {    
            if(creditCardNumber == null)
                return RedirectToActionPermanent("Error", new { reason = "Please enter a valid number." });
            try
            {
                var creditCardNumberSanitized = creditCardNumber.Replace("-", string.Empty);
                return RedirectToActionPermanent("EnterPing", new { creditCardNumberSanitized });
            }
            catch (ATMException ex)
            {
                return RedirectToActionPermanent("Error", new { reason = ex.Message });                
            }
        }

        public ActionResult EnterPing(string creditCardNumber, bool pinFailed)
        {
            ViewBag.CreditCardNumber = creditCardNumber;
            ViewBag.PinFailed = pinFailed;
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Exit()
        {
            return RedirectToAction("Index","Login");
        }

        public ActionResult Error(string reason)
        {
            ViewBag.Reason = reason;
            return View();
        }
    }
}