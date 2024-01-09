namespace MU.Domain.ValueObjects
{
    public partial record Address
    {
        private Address(string city, string state, string line1, string line2, string zipCode)
        {
            City = city;
            State = state;
            Line1 = line1;
            Line2 = line2;
            ZipCode = zipCode;
        }

        public string City { get; init; }
        public string State { get; init; }
        public string Line1 { get; init; }
        public string Line2 { get; init; }
        public string ZipCode { get; init; }
        public string AddressString => $"{City}, {State}, {Line1} {Line2}, {ZipCode}";
        public static explicit operator string(Address address) => address.AddressString;

        public static Address? Create(string city, string state, string line1, string line2, string zipCode)
        {
            if (String.IsNullOrEmpty(city) || String.IsNullOrEmpty(state)
                || (String.IsNullOrEmpty(line1) && String.IsNullOrEmpty(line2)) 
                || String.IsNullOrEmpty(zipCode))
            {
                return null;
            }

            return new Address(city, state, line1, line2, zipCode);
        }
    }
}
