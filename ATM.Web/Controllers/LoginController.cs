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
            if (creditCardNumber == null)
                return RedirectToActionPermanent("Error", new { reason = "Please enter a valid number." });

            try
            {
                var creditCardNumberSanitized = creditCardNumber.Replace("-", string.Empty);
                var creditCard = this._ccService.Exists(creditCardNumberSanitized);
                return RedirectToActionPermanent("EnterPing", new { creditCardNumber });
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

        [HttpPost]
        public ActionResult EnterPingPost(string creditCardNumber, string creditCardPin)
        {
            try
            {
                var creditCardNumberSanitized = creditCardNumber.Replace("-", string.Empty);
                var creditCard = this._ccService.GetByParameters(new string[] { creditCardNumberSanitized, creditCardPin });
                return RedirectToActionPermanent("Home", "Atm", new { creditCardId = creditCard.Id });
            }
            catch (ATMException)
            {
                return RedirectToActionPermanent("EnterPing", new { creditCardNumber, pinFailed = true });
            }
            catch (ATMCardBlockedException ex)
            {
                return RedirectToActionPermanent("Error", new { reason = ex.Message });
            }
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Exit()
        {
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Error(string reason)
        {
            ViewBag.Reason = reason;
            return View();
        }
    }
}