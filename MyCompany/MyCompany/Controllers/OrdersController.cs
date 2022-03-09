using System;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;

namespace MyCompany.Controllers
{
    public class OrdersController: Controller

    {
        private readonly DataManager dataManager;

        public OrdersController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.Orders.GetOrderById(id));
            }

            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageServices");
            var orders = dataManager.Orders.GetOpenOrders();
            return View(orders);
        }
    }
}
