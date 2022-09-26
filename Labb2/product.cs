using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2;

public class Product
{
    private string _name;

    private double _price;
    
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
        
    public double price
    {
        get { return _price; }
        set
        {
            _price = value;
        }
    }
    
}