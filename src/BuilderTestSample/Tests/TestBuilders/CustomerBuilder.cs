using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class CustomerBuilder
    {
        private int _id;
        private int _creditRating;
        private string _firstName;
        private string _lastName;
        private decimal _totalPurchases;

        private Address _homeAddress;

        public CustomerBuilder Id(int id)
        {
            _id = id;
            return this;
        }

        public CustomerBuilder Address(Address homeAddress)
        {
            _homeAddress = homeAddress;
            return this;
        }

        public CustomerBuilder FirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }
        public CustomerBuilder CreditRating(int creditRating)
        {
            _creditRating = creditRating;
            return this;
        }

        public CustomerBuilder TotalPurchases(decimal totalPurchases)
        {
            _totalPurchases = totalPurchases;
            return this;
        }
        public CustomerBuilder HomeAddress(Address homeAddress)
        {
            _homeAddress = homeAddress;
            return this;
        }

        public Customer Build()
        {
            var _customer = new Customer(_id)
            {
                FirstName = _firstName,
                CreditRating = _creditRating,
                LastName = _lastName,
                TotalPurchases = _totalPurchases,
                HomeAddress = _homeAddress
            };

            return _customer;
        }

        public CustomerBuilder WithTestValues()
        {
            _id = 1;
            _creditRating = 10;
            _firstName = "Peter";
            _lastName = "Jones";
            _totalPurchases = 827.65m;
            _homeAddress = new Address();

            return this;
        }
    }
}
