using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SacredBond.App.Models.Subscription;
using SacredBond.Core.Domain;
using Stripe;
using Microsoft.Extensions.Configuration;
using SacredBond.Common.Configs;
using SacredBond.Core.Services;
using System.Security.Principal;
using SacredBond.Core.Contexts;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
using SacredBond.Core.Financial;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using Stripe.Issuing;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SacredBond.App.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IConfiguration _configuration;
        private readonly IFinancialService _financialService;

        public SubscriptionController(IProfileService profileService, IConfiguration configuration, IFinancialService financialService)
        {
            profileService = profileService;
            _configuration = configuration;
            _financialService = financialService;
        }
        
        public IActionResult NewCardRegistration(NewCardRegistrationViewModel viewModel)
        {
            if(viewModel == null || viewModel.CVC == null)
            {
                string stripeCustomerId = TempData["stripeCustomerId"] as string;
                // Step 1: Retrieve the customer using StripeCustomerId
                var customerService = new CustomerService();
                var customer = customerService.Get(stripeCustomerId);
                viewModel = new NewCardRegistrationViewModel();
                viewModel.stripeCustomerId = stripeCustomerId;
            }
            return View(viewModel);
        }
     

        [HttpPost]
        public IActionResult NewCardRegistrationForm(NewCardRegistrationViewModel viewModel)
        {
            TempData["stripeCustomerId"] = viewModel.stripeCustomerId;
            string result = _financialService.UpdateSubscription(viewModel.CardNumber, viewModel.EXPMonth, viewModel.EXPYear, viewModel.CVC, viewModel.stripeCustomerId);
            if(!String.Equals(result, "success"))
            {
                return RedirectToAction("NewCardRegistration", "Subscription", new
                {
                    viewModel = viewModel
                }) ;
            }
            return RedirectToAction("Index", "Home"); // Return the view with validation errors
        }

    }
}

