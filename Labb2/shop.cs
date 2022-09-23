using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    internal class shop : product
    {
        public List<product> Sortiment = new List<product>();

        public product AddtoCart(List<product> Sortiment)
        {
            return Sortiment[1];
        }

        public void PrintSorti(List<product> Sortiment)
        {
            foreach (var VARIABLE in this.Sortiment)
            {
                
            }
        }
    }
}
