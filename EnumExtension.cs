using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stammbaumgenerator
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
    }
}
