using BuilderTestSample.Exceptions;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using Xunit;

namespace BuilderTestSample.Tests
{
    public class OrderServicePlaceOrder
    {
        private readonly OrderService _orderService = new OrderService();
        private readonly OrderBuilder _orderBuilder = new OrderBuilder();

        [Fact]
        public void ThrowsExceptionGivenOrderWithExistingId()
        {
            var order = _orderBuilder
                            .WithTestValues(null)
                            .Id(123)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenOrderWithoutTotalAmountZero()
        {
            // Arrange
            var order = _orderBuilder
                            .WithTestValues(null)
                            .Id(123)
                            .Build();

            // Act
            order.TotalAmount = 0;


            // Assert
            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionWhenCustomerIsNull()
        {
            var order = _orderBuilder
                            .WithTestValues(null)
                            .Id(123)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionWhenCustomerIdNotGreaterThanZero()
        {
            var customer = new CustomerBuilder()
                .WithTestValues()
                .Id(0)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();            

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionWhenCustomerAddressIsNull()
        {
            var customer = new CustomerBuilder()
                .WithTestValues()
                .Address(null)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionWhenCustomerFirstNameIsNull()
        {
            var customer = new CustomerBuilder()
                .WithTestValues()
                .FirstName(null)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionWhenCustomerFirstNameIsEmpty()
        {
            var customer = new CustomerBuilder()
                .WithTestValues()
                .FirstName(string.Empty)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionWhenCustomerFirstNameIsWhiteSpace()
        {
            var customer = new CustomerBuilder()
                .WithTestValues()
                .FirstName("  ")
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionWhenCustomerCreditRatingNotGreaterThan200()
        {
            var customer = new CustomerBuilder()
                .WithTestValues()
                .CreditRating(200)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            Assert.Throws<InsufficientCreditException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionWhenCustomerTotalPurcahsesIsNegative()
        {
            var customer = new CustomerBuilder()
                .WithTestValues()
                .CreditRating(201)
                .TotalPurchases(-0.1m)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionWhenAddressStreet1IsNull()
        {
            var homeAddress = new AddressBuilder()
                .WithTestValues()
                .Street1(null)
                .Build();

            var customer = new CustomerBuilder()
                .WithTestValues()
                .HomeAddress(homeAddress)
                .CreditRating(201)
                .TotalPurchases(871.45m)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionWhenAddressStreet1IsEmpty()
        {
            var homeAddress = new AddressBuilder()
                .WithTestValues()
                .Street1(string.Empty)
                .Build();

            var customer = new CustomerBuilder()
                .WithTestValues()
                .HomeAddress(homeAddress)
                .CreditRating(201)
                .TotalPurchases(871.45m)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionWhenAddressStreet1IsWhiteSpace()
        {
            var homeAddress = new AddressBuilder()
                .WithTestValues()
                .Street1("  ")
                .Build();

            var customer = new CustomerBuilder()
                .WithTestValues()
                .HomeAddress(homeAddress)
                .CreditRating(201)
                .TotalPurchases(871.45m)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }


        [Fact]
        public void ThrowsExceptionWhenAddressCityIsNull()
        {
            var homeAddress = new AddressBuilder()
                .WithTestValues()
                .City(null)
                .Build();

            var customer = new CustomerBuilder()
                .WithTestValues()
                .HomeAddress(homeAddress)
                .CreditRating(201)
                .TotalPurchases(871.45m)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }


        [Fact]
        public void ThrowsExceptionWhenAddressStateIsNull()
        {
            var homeAddress = new AddressBuilder()
                .WithTestValues()
                .State(null)
                .Build();

            var customer = new CustomerBuilder()
                .WithTestValues()
                .HomeAddress(homeAddress)
                .CreditRating(201)
                .TotalPurchases(871.45m)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }



        [Fact]
        public void ThrowsExceptionWhenAddressPostalCodeIsNull()
        {
            var homeAddress = new AddressBuilder()
                .WithTestValues()
                .PostalCode(null)
                .Build();

            var customer = new CustomerBuilder()
                .WithTestValues()
                .HomeAddress(homeAddress)
                .CreditRating(201)
                .TotalPurchases(871.45m)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionWhenAddressCountryIsNull()
        {
            var homeAddress = new AddressBuilder()
                .WithTestValues()
                .Country(null)
                .Build();

            var customer = new CustomerBuilder()
                .WithTestValues()
                .HomeAddress(homeAddress)
                .CreditRating(201)
                .TotalPurchases(871.45m)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ExpediteOrder()
        {
            var homeAddress = new AddressBuilder()
                .WithTestValues()
                .Build();

            var customer = new CustomerBuilder()
                .WithTestValues()
                .HomeAddress(homeAddress)
                .CreditRating(501)
                .TotalPurchases(5001m)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            _orderService.PlaceOrder(order);
            Assert.True(order.IsExpedited);
        }


        [Fact]
        public void AddOrderToCustomerHistory()
        {
            var homeAddress = new AddressBuilder()
                .WithTestValues()
                .Build();

            var customer = new CustomerBuilder()
                .WithTestValues()
                .HomeAddress(homeAddress)
                .CreditRating(501)
                .TotalPurchases(5001m)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            _orderService.PlaceOrder(order);
            Assert.True(customer.OrderHistory.Count == 1);
        }



        [Fact]
        public void UpdateTotalPurchases()
        {
            var startingTotalPurchases = 5001m;
            var homeAddress = new AddressBuilder()
                .WithTestValues()
                .Build();

            var customer = new CustomerBuilder()
                .WithTestValues()
                .HomeAddress(homeAddress)
                .CreditRating(501)
                .TotalPurchases(startingTotalPurchases)
                .Build();

            var order = _orderBuilder
                            .WithTestValues(customer)
                            .Build();

            _orderService.PlaceOrder(order);
            Assert.True(customer.TotalPurchases == startingTotalPurchases + order.TotalAmount);
        }

    }
}
