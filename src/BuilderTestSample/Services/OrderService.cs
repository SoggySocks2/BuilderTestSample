using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;

namespace BuilderTestSample.Services
{
    public class OrderService
    {
        public void PlaceOrder(Order order)
        {
            ValidateOrder(order);

            ExpediteOrder(order);

            AddOrderToCustomerHistory(order);
        }

        private void ValidateOrder(Order order)
        {
            if (order.Id != 0) throw new InvalidOrderException("Order ID must be 0.");

            if (!(order.TotalAmount > 0)) throw new InvalidOrderException("TotalAmount must be greater than 0.");

            if (order.Customer is null) throw new InvalidOrderException("Customer can not be null.");

            ValidateCustomer(order.Customer);
        }

        private void ValidateCustomer(Customer customer)
        {
            if(!(customer.Id > 0)) throw new InvalidOrderException("Customer id must be greater than 0.");

            if (customer.HomeAddress is null) throw new InvalidOrderException("Customer address can not be null.");

            if (string.IsNullOrWhiteSpace(customer.FirstName)) throw new InvalidOrderException("Customer must have a first name.");

            if (!(customer.CreditRating > 200)) throw new InsufficientCreditException("Customer credit rating must be greater than 200.");

            if (customer.TotalPurchases < 0) throw new InvalidOrderException("Customer total purchases can not be negative.");

            ValidateAddress(customer.HomeAddress);
        }

        private void ValidateAddress(Address homeAddress)
        {
            if (string.IsNullOrWhiteSpace(homeAddress.Street1)) throw new InvalidAddressException("Address must have a street 1.");

            if (string.IsNullOrWhiteSpace(homeAddress.City)) throw new InvalidAddressException("Address must have a city.");

            if (string.IsNullOrWhiteSpace(homeAddress.State)) throw new InvalidAddressException("State must have a city.");

            if (string.IsNullOrWhiteSpace(homeAddress.PostalCode)) throw new InvalidAddressException("State must have a postal code.");

            if (string.IsNullOrWhiteSpace(homeAddress.Country)) throw new InvalidAddressException("State must have a country.");
        }

        private void ExpediteOrder(Order order)
        {
            if(order.Customer.TotalPurchases > 5000 && order.Customer.CreditRating > 500)
            {
                order.IsExpedited = true;
            }
        }

        private void AddOrderToCustomerHistory(Order order)
        {
            order.Customer.OrderHistory.Add(order);

            order.Customer.TotalPurchases += order.TotalAmount;
        }
    }
}
