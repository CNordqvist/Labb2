using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    internal class User
    {

        public string Name { get; set; }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public char Tier { get; set; }

        public void ToStringer(string Name, string Password, char Tier)
        {

        }
    }
}
