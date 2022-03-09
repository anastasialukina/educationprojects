using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MyCompany.Domain;

namespace MyCompany.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly DataManager dataManager;

        public HomeController(UserManager<IdentityUser> userManager, DataManager dataManager)
        {
            this.userManager = userManager;
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.Orders.GetOrdersByCustomer(userManager.GetUserId(User)));
        }
    }
}