using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponent.Enum
{
    public static class ExtensionMethod
    {
        public static Colour GetOpposite(this Colour colour)
        {
            if (colour == Colour.White)
            {
                return Colour.Black;
            }

            return Colour.White;
        }
    }
}
