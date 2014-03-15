namespace IasiDevDemo.Infrastructure
{
    public class Dal
    {
        public void UpdateCustomer(Customer customer)
        {
            var customerRepository = new CustomerRepository();
            if (customer.Id.HasValue)
                customerRepository.ChangeName(customer.Name);
        }
    }
}