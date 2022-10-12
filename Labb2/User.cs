using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Labb2;

public class User
{
    private string _name;
    private string _password;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    public List<Product> ShoppingCart = new List<Product>();

    

}