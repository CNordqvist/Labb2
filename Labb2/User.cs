using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Labb2;

public class User : Cart
{

    public string Name { get; set; }
    private string _password;

    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    public char Tier { get; set; }
        
}