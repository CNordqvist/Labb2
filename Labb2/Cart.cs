using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    internal class Cart : User
    {
        List<product> shoppingCart = new List<product>();
        int pricetotal;
        public void PrintCart(List<product> shoppingCart)
        {

        }

        public List<product> RemoveOne(List<product> shoppingCart)
        {
            return shoppingCart;
        }

        public double PriceTotal(List<product> shoppingCart)
        {
            return pricetotal;
        }
    }
}
