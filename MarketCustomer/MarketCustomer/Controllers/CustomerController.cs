using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketCustomer.Models.Entity;

namespace MarketCustomer.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        customerEntities db = new customerEntities();
        public ActionResult Index()
        {
            var values = db.customer.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(customer customer)
        {
            if (!ModelState.IsValid) //doğrulama yapılmadıysa
            {
                return View("AddCustomer");
            }
            db.customer.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var customer = db.customer.Find(id);
            db.customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult customerList(int id)
        {
            var customer = db.customer.Find(id);
            return View("customerList", customer);
        }
        public ActionResult UpdateCustomer(customer customer)
        {
            var customers = db.customer.Find(customer.customerId);
            customers.customerFirstName = customer.customerFirstName;
            customers.customerLastName = customer.customerLastName;
            customers.customerPhoneNumber = customer.customerPhoneNumber;
            customers.customerAddress = customer.customerAddress;
            customers.customerDebt = customer.customerDebt;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}