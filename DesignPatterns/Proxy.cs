using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class Property<T> : IEquatable<Property<T>> where T : new()
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if(Equals(this._value,value)) return;
                Console.WriteLine($"Assigning value to {value}");
                _value = value;
            }
        }

        public Property() : this(default(T))// this(Activator.CreateInstance<T>())
        {
        }

        public static implicit operator T(Property<T> property)
        {
            return property._value; //int n = p_int;
        }

        public static implicit operator Property<T>(T property)
        {
            return new Property<T>(property); //Property<int> p =123;
        }

        public bool Equals(Property<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(_value, other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Property<T>) obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(Property<T> left, Property<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Property<T> left, Property<T> right)
        {
            return !Equals(left, right);
        }

        public Property(T value)
        {
            _value = value;
        }
    }

}