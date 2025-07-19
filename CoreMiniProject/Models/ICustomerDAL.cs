namespace CoreMiniProject.Models
{
    public interface ICustomerDAL
    {
        List<Customer> Customers_Select();

        void Customer_Insert(Customer customer);

        Customer Customer_Select_Id(int Custid);

       void Customer_Update(Customer customer);

       void Customer_Delete(int Custid);
    }

}
