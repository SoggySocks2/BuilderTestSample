using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class AddressBuilder
    {
        private string _street1;
        private string _street2;
        private string _street3;
        private string _city;
        private string _state;
        private string _postalCode;
        private string _country;

        public AddressBuilder()
        {

        }

        public AddressBuilder Street1(string street1)
        {
            _street1 = street1;
            return this;
        }

        public AddressBuilder City(string city)
        {
            _city = city;
            return this;
        }

        public AddressBuilder State(string state)
        {
            _state = state;
            return this;
        }

        public AddressBuilder PostalCode(string postalCode)
        {
            _postalCode = postalCode;
            return this;
        }

        public AddressBuilder Country(string country)
        {
            _country = country;
            return this;
        }

        public Address Build()
        {
            var address = new Address
            {
                Street1 = _street1,
                Street2 = _street2,
                Street3 = _street3,
                City = _city,
                State = _state,
                PostalCode = _postalCode,
                Country = _country
            };

            return address;
        }

        public AddressBuilder WithTestValues()
        {
            _street1 = "Some street";
            _street2 = "Some where";
            _street3 = "Some town";
            _city = "Some city";
            _state = "Some state";
            _postalCode = "Some postal code";
            _country = "Some ciuntry";

            return this;
        }
    }
}
