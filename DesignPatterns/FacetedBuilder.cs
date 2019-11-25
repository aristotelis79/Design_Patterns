namespace DesignPatterns
{
    public class FacetedBuilder
    {
        public class Person
        {
            //address
            public string StreetAddress, Postcode, City;

            public string CompanyName, Position;

            public int AnnualIncome;

            public static implicit operator Person(PersonBuilder pb)
            {
                return pb.Person;
            }

            public override string ToString()
            {
                return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
            }
        }


        public class PersonBuilder //Facade
        {
            //reference!
            public Person Person = new Person();

            public PersonJobBuilder Works => new PersonJobBuilder(Person);
            public PersonAddressBuilder Lives => new PersonAddressBuilder(Person);
        }

        public class PersonJobBuilder : PersonBuilder
        {
            public PersonJobBuilder(Person person)
            {
                this.Person = person;
            }

            public PersonJobBuilder At(string companyName)
            {
                this.Person.CompanyName = companyName;
                return this;
            }

            public PersonJobBuilder AsA(string position)
            {
                this.Person.Position = position;
                return this;
            }

            public PersonJobBuilder Earning(int amount)
            {
                this.Person.AnnualIncome = amount;
                return this;
            }
        }

        public class PersonAddressBuilder : PersonBuilder
        {
            //might not work with value type
            public PersonAddressBuilder(Person person)
            {
                this.Person = person;
            }

            public PersonAddressBuilder At(string streetAddress)
            {
                this.Person.StreetAddress = streetAddress;
                return this;
            }

            public PersonAddressBuilder WithPostcode(string postcode)
            {
                this.Person.Postcode = postcode;
                return this;
            }

            public PersonAddressBuilder In(string city)
            {
                this.Person.City = city;
                return this;
            }
        }
    }
}