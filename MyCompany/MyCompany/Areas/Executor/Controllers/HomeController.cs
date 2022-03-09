using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;

namespace MyCompany.Areas.Executor.Controllers
{
    [Area("Executor")]
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
            return View(dataManager.Orders.GetOpenOrders());
        }
    }
}