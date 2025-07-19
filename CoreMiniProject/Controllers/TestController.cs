using Microsoft.AspNetCore.Mvc;
using CoreMiniProject.Models;
namespace CoreMiniProject.Controllers
{
    public class TestController : Controller
    {
        //CustomerDAL obj = new CustomerDAL();

        ICustomerDAL obj; // Obj is an reference 

        public TestController(ICustomerDAL obj) // Create an test Constrcuor

        {
            this.obj = obj;
        }
        public IActionResult DisplayCustomers()
        {
            return View(obj.Customers_Select());
        }

        [HttpGet]
        public ViewResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public RedirectToActionResult AddCustomer(Customer customer)
        {
            obj.Customer_Insert(customer);
            return RedirectToAction("DisplayCustomers");
        }
        public IActionResult DisplayCustomer(int Custid)
        {
            return View(obj.Customer_Select_Id(Custid));
        }

        public IActionResult EditCustomer(int Custid)
        {
            return View(obj.Customer_Select_Id(Custid));
        }
        public RedirectToActionResult UpdateCustomer(Customer customer)
        {
            obj.Customer_Update(customer);
            return RedirectToAction("DisplayCustomers");
        }
        public RedirectToActionResult DeleteCustomer(int Custid)
        {
            obj.Customer_Delete(Custid);
            return RedirectToAction("DisplayCustomers");
        }

    }
}
