using CoreMiniProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace CoreMiniProject.Controllers
{

    [Authorize]
    public class TestController : Controller
    {
        //CustomerDAL obj = new CustomerDAL();

        ICustomerDAL obj; // Obj is an reference 

        public TestController(ICustomerDAL obj) // Create an test Constrcuor

        {
            this.obj = obj;
        }

        [AllowAnonymous]
        public IActionResult DisplayCustomers()
        {
            return View(obj.Customers_Select());
        }


        [Authorize]
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

        [Authorize]
        public IActionResult EditCustomer(int Custid)
        {
            return View(obj.Customer_Select_Id(Custid));
        }
        [Authorize]
        public RedirectToActionResult UpdateCustomer(Customer customer)
        {
            obj.Customer_Update(customer);
            return RedirectToAction("DisplayCustomers");
        }

        [Authorize]
        public RedirectToActionResult DeleteCustomer(int Custid)
        {
            obj.Customer_Delete(Custid);
            return RedirectToAction("DisplayCustomers");
        }

    }
}
