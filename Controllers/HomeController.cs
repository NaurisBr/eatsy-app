﻿using eatsy_app.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eatsy_app.Controllers
{
    public class HomeController : Controller
    {
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
    }
}