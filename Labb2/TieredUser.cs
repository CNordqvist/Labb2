using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class TieredUser : User
    {

        private char _tier;

        public char Tier
        {
            get { return _tier; }
            set { _tier = value; }
        }

        public override string ToString()
        {
            var toStringRet = string.Empty;

            toStringRet += $"N:{Name}&PW:{Password}?T:{Tier}!";

            return toStringRet;
        }
    }
}
