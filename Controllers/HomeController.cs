﻿using eatsy_app.Models;
using eatsy_app.Repositories;
using eatsy_app.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eatsy_app.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantDBEntities objRestaurantDbEntities;

        public HomeController()
        {
            objRestaurantDbEntities = new RestaurantDBEntities();

        }
        // GET: Home
        public ActionResult Index()
        {

            CustomerRepository objCustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository(); 


            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (objCustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentTypeRepository.GetAllPaymentTypes());

            return View(objMultipleModels);

        } 

        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = objRestaurantDbEntities.Items.Single(model => model.ItemID == itemId).ItemPrice;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {

            OrderRepository objOrderRepository = new OrderRepository();
            objOrderRepository.AddOrder(objOrderViewModel);

            return Json("Your order has been successfully placed!", JsonRequestBehavior.AllowGet);  
        }
    }
}