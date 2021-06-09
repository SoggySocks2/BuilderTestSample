using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    /// <summary>
    /// Reference: https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    /// </summary>
    public class OrderBuilder
    {
        private readonly Order _order = new Order();

        public OrderBuilder Id(int id)
        {
            _order.Id = id;
            return this;
        }

        public Order Build()
        {
            return _order;
        }

        public OrderBuilder WithTestValues(Customer customer)
        {
            _order.Id = 0;
            _order.TotalAmount = 100m;
            _order.Customer = customer;

            if (customer != null)
            {
                _order.Customer.HomeAddress = customer.HomeAddress;
            }

            return this;
        }
    }
}
