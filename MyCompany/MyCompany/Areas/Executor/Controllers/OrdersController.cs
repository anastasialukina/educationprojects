using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Service;


namespace MyCompany.Areas.Executor.Controllers
{
    [Area("Executor")]
    public class OrdersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;

        public OrdersController(UserManager<IdentityUser> userManager, DataManager dataManager,
            IWebHostEnvironment hostingEnvironment)
        {
            this.userManager = userManager;
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Order() : dataManager.Orders.GetOrderById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Order model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream =
                           new FileStream(
                               Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName),
                               FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }

                model.ExecutorId = userManager.GetUserId(User);

                dataManager.Orders.SaveOrder(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }

            return View(model);
        }
    }
}