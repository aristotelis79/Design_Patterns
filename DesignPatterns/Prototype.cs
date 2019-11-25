using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace DesignPatterns
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                var copy = formatter.Deserialize(stream);
                stream.Close();
                return (T) copy;
            }
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, self);
                stream.Position = 0;
                return (T) serializer.Deserialize(stream);
            }
        }
    }

    //public interface IPrototype<T>
    //{
    //    T DeepCopy();
    //}

    [Serializable]
    public class Person //: IPrototype<Person>
    {
        public string[] Names;
        public Address Address;

        public Person()
        {
        }

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        //public Person(Person person)
        //{
        //    Names = person.Names;
        //    Address =new Address(person.Address);
        //}

        //public Person DeepCopy()
        //{
        //    return new Person(Names, Address.DeepCopy());
        //}

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    [Serializable]
    public class Address //:IPrototype<Address>
    {
        public string StreetName;
        public int HouseNumber;

        public Address()
        {
        }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        //public Address(Address address)
        //{
        //    StreetName = address.StreetName;
        //    HouseNumber = address.HouseNumber;
        //}

        //public Address DeepCopy()
        //{
        //    return new Address(StreetName,HouseNumber);
        //}

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }
}