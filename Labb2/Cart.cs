using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2;

public class Cart : User
{
    List<Product> shoppingCart = new List<Product>();
    int pricetotal;
    public void PrintCart(List<Product> shoppingCart)
    {

    }

    public List<Product> RemoveOne(List<Product> shoppingCart)
    {
        return shoppingCart;
    }

    public double PriceTotal(List<Product> shoppingCart)
    {
        return pricetotal;
    }
}