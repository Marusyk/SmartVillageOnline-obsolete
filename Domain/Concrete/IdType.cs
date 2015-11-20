using System;

namespace Domain.Concrete
{
    public struct IdType // : IComparable, IFormattable, etc..
    {
        private int value;

        public static readonly IdType MinValue = new IdType() { value = 0 };
        public static readonly IdType MaxValue = new IdType() { value = int.MaxValue };

        private IdType(int temp)
        {
            if(temp < IdType.MinValue)
                throw new ArgumentOutOfRangeException("temp", "Value cannot be less then IdType.MinValue (absolute zero)");
            if (temp > IdType.MaxValue)
                throw new ArgumentOutOfRangeException("temp", "Value cannot be more then IdType.MaxValue");
            value = temp;
        }

        public static implicit operator IdType(int temp)
        {
            return new IdType(temp);
        }

        public static implicit operator int(IdType id)
        {
            return id.value;
        }

        // operators for other numeric types...

        public override string ToString()
        {
            return value.ToString();
        }
        // override Equals, HashCode, etc...
    }
}
