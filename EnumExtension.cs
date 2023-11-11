using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeGenerator
{
    public static class EnumExtension
    {
        private static Random random = new Random();

        public static Enum RandomEnum(Type type)
        {
            Array values = Enum.GetValues(type);
            Enum randomBar = (Enum)values.GetValue(random.Next(values.Length));

            return randomBar;
        }

        public static T ToggleEnumValue<T>(T value)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            // Toggle between the two enum values
            Array enumValues = Enum.GetValues(typeof(T));
            int currentIndex = Array.IndexOf(enumValues, value);
            int nextIndex = (currentIndex + 1) % enumValues.Length;

            return (T)enumValues.GetValue(nextIndex);
        }
    }
}
