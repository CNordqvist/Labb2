﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2;

public class Cart
{
    public List<Product> ShoppingCart = new List<Product>();
    
    public void PrintCart(List<Product> shoppingCart)
    {

    }

    public List<Product> RemoveOne(List<Product> shoppingCart)
    {
        return shoppingCart;
    }
    
}