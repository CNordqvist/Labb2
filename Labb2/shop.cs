using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Labb2;

public class shop
{
    public List<Product> Sortiment = new List<Product>();
    
    public List<Product> SortiFill(List<Product> Sortiment)
    {
    Product gurka = new Product() { Name = "Cucumber", Price = 40 };
    Sortiment.Add(gurka);
    Product tomat = new Product() { Name = "Tomato", Price = 30 };
    Sortiment.Add(tomat);
    Product sallad = new Product() { Name = "Lettuce", Price = 25 };
    Sortiment.Add(sallad);

    return Sortiment;
    }
    
}