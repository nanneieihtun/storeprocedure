using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TradexWeb.Models;
using TradexWeb.ViewModel;

namespace TradexWeb.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using (var context = new CustomerEntities())
            {
                var data = context.Customers_PerformCRUD("select", null, null, null, null, null, null, null, null, null,
                    null, null).ToList();
                List<CustomerViewModel> vmlist = new List<CustomerViewModel>();
                foreach (var  res in data)
                {
                    CustomerViewModel vm = new CustomerViewModel();
                    vm.CustomerId = res.CustomerID;
                    vm.CompanyName = res.CompanyName;
                    vm.Address = res.Address;
                    vm.ContactTitle = res.ContactTitle;
                    vm.Phone = res.Phone;
                    vm.Fax = res.Fax;
                    vm.ContactName = res.ContactName;
                    vm.City = res.City;
                    vm.Region = res.Region;
                    vm.PostalCode = res.PostalCode;
                    vm.Country = res.Country;
                    vmlist.Add(vm);

                }
                return View(vmlist);
            }
        }
        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerViewModel model)
        {
           try
           {
                using (var context = new CustomerEntities())
                {

                    var data = context.Customers_PerformCRUD("insert", Guid.NewGuid().ToString(), model.CompanyName, model.ContactName, model.ContactTitle, model.Address, model.City, model.Region, model.PostalCode, model.Country,
                        model.Phone, model.Fax).FirstOrDefault();
                    return RedirectToAction("Index");
                }
              
           }
           catch(Exception ex)
           {
               var message = ex.Message;
               return RedirectToAction("Index");
           }
        }

        // GET: Customer/Edit
        public ActionResult Edit(string customerId)
        {
            using (var context = new CustomerEntities())
            {
                var data = context.Customers_PerformCRUD("get", customerId, null, null, null, null, null, null, null, null,
                    null, null).FirstOrDefault();
                return View(data);
            }
        }

        // POST: Customer/Edit

        [HttpPost]
        public ActionResult Edit( Customer model)
        {
            try
            {
                using (var context = new CustomerEntities())
                {
                    var data = context.Customers_PerformCRUD("update", model.CustomerID, model.CompanyName, model.ContactName, model.ContactTitle, model.Address, model.City, model.Region, model.PostalCode, model.Country,
                        model.Phone, model.Fax).ToList();
                    return RedirectToAction("Index");
                }
              
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    
        // GET: Customer/Delete/

        [HttpGet]
        [Route("Delete")]
        public ActionResult Delete(string customerId)
        {
            try
            {
                using (var context = new CustomerEntities())
                {
                    var data = context.Customers_PerformCRUD("delete", customerId, null, null, null, null, null, null, null, null,
                        null, null);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
