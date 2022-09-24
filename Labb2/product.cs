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

    private double _priceZim;
    private double _priceVen;


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
            _priceZim = value * 29.068442;
            _priceVen = value * 20384900000;
        }
    }

    public double priceZim
    {
        get { return _priceZim; }
    }

    public double priceVen
    {
        get { return _priceVen; }
    }
}