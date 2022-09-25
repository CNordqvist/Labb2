using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Labb2;

public class shop
{
    private Global screen = new Global();
    public List<Product> Sortiment = new List<Product>();
    
    public List<Product> SortiFill(List<Product> Sortiment)
    {
    Product gurka = new Product() { name = "Cucumber", price = 50 };
    Sortiment.Add(gurka);
    Product vaselin = new Product() { name = "Vaseline", price = 75 };
    Sortiment.Add(vaselin);
    Product kondomer = new Product() { name = "Condoms", price = 110 };
    Sortiment.Add(kondomer);

    return Sortiment;
    }
    


    public Product AddtoCart(List<Product> Sortiment)
    {

        return Sortiment[1];
    }

    public void PrintSorti(List<Product> Sortiment)
    {
        foreach (var VARIABLE in Sortiment)
        {
            screen.NewScreen();
            screen.Center();
            Console.WriteLine(this.Sortiment.ToString());
        }
    }
}