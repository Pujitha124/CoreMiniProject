
namespace CoreMiniProject.Models
{
    public class CustomerSqlDAL : ICustomerDAL
    {
        CoreMini context;

        public CustomerSqlDAL(CoreMini context)
        {
            this.context = context;
        }
        public List<Customer> Customers_Select()
        {
            try
            {
                var customers = context.Customers.Where(C => C.Status == true).ToList();
                return customers;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        public Customer Customer_Select_Id(int Custid)
        {
            return context.Customers.Find(Custid);
        }
        public void Customer_Insert(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }
        public void Customer_Update(Customer customer)
        {
            customer.Status = true;
            context.Update(customer);
            context.SaveChanges();
        }
        public void Customer_Delete(int Custid)
        {
            Customer customer = context.Customers.Find(Custid);
            customer.Status = false;
            context.SaveChanges();
        }
    }
}
