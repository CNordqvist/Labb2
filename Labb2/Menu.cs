using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class Menu
    {
        Global screen = new Global();
        public void IntroScreen(UserBase currentUsers, shop theShop)
        {
            
            while (true)
            {
                // Logga in eller regga nytt konto meny;
                screen.NewScreen();
                screen.PrintRed("Hello and welcome to\n");
                screen.PrintBanner(); 
                screen.Print("Log in or Register a new account?\n\n");
                var loggedinUser = new TieredUser();

                string userInput = screen.Read();
                
                
                if (userInput is "register" or "Register")
                {
                    currentUsers.Register(currentUsers.UserList);
                    loggedinUser = (TieredUser)currentUsers.LogIn(currentUsers.UserList);

                }
                else if (userInput is "login" or "Login" or "log in" or "Log in")
                {
                   loggedinUser = (TieredUser)currentUsers.LogIn(currentUsers.UserList);
                }
                else
                {
                    screen.Print("Unrecognized input, please try again");
                    Thread.Sleep(1000);
                    continue;
                }

                //navigerings-meny
                while (true)
                {
                    screen.NewScreen();
                    Console.Write("Logged in as:" + loggedinUser.Name);
                    
                    screen.Print("vad vill du göra?");
                    screen.Print("[B]uy / View [S]hoppingcart / [L]og out / [T]oString");
                    
                    userInput = screen.Read();

                    if
                        (userInput is "Buy" or "buy" or "B" or "b")
                    {
                        while (true)
                        {
                            //Printa sortimentet
                            screen.NewScreen();
                            foreach (var product in theShop.Sortiment)
                            {
                                Console.WriteLine( "  " + product.Name +
                                       "   SeK : " + product.Price + "\n" +
                                       "   Zimbabwean dollars : " + screen.ZimRate(product.Price) +
                                       "   Venezuelan bolivar : " + screen.VenRate(product.Price) + "\n\n");
                            }

                            //lägg till i användarens shoppingCart
                            screen.Print("What would you like to buy? [M] for menu");
                            
                            userInput = screen.Read();
                            if (userInput is "m" or "M")
                            {
                                break;
                            }
                            else
                            {
                                foreach (var product in theShop.Sortiment)
                                {
                                    if (userInput == product.Name)
                                    {
                                        loggedinUser.ShoppingCart.Add(product);
                                        screen.Print(product.Name + " has been added to your shopping cart.");
                                        Thread.Sleep(500);
                                    }
                                }
                            }
                        }
                    }

                    else if
                    (userInput is "Shoppingcart" or "shoppingcart" or "S" or "s")
                    {
                        
                        while (true)
                        {
                            double fullPrice = 0;
                            int itemsAmount = 0;
                            double sekSaved = 0;

                            //se object användaren har lagt i kundvagn och totalpriset för alla saker. 
                            screen.NewScreen();
                            foreach (var product in loggedinUser.ShoppingCart)
                            {
                                Console.WriteLine(product.Name +
                                $"  Sek : " + product.Price +
                                $"\nZimbabwean dollars : " + screen.ZimRate(product.Price) +
                                $"  Venezuelan bolivar : " + screen.VenRate(product.Price) + "\n\n");

                                fullPrice = fullPrice + product.Price;
                                itemsAmount++;
                            }

                            //Kolla på användarens Tier för att konvertera totalpriset
                            if (loggedinUser.Tier == 'G')
                            {
                                fullPrice = fullPrice - (fullPrice * 0.15);
                                sekSaved = fullPrice * 0.15;
                            }
                            else if (loggedinUser.Tier == 'S')
                            {
                                fullPrice = fullPrice - (fullPrice * 0.10);
                                sekSaved = fullPrice * 0.10;
                            }
                            else if (loggedinUser.Tier == 'B')
                            {
                                fullPrice = fullPrice - (fullPrice * 0.5);
                                sekSaved = (fullPrice * 0.5);
                            }
                            
                            //visa det konverterade totalpriset och gör valuta omvandling
                            Console.WriteLine($"{itemsAmount}items. The total price for you is currently " + 
                                         $" Sek : {fullPrice}    " +
                                         $"{Math.Round(sekSaved, 2)}Kr saved via your discount\n" +
                                         $"Zimbabwean dollars :{screen.ZimRate(fullPrice)}   \n" +
                                         $"Venezuelan bolivars :{screen.VenRate(fullPrice)}\n" );


                            screen.Print("What would you like to do?");
                            screen.Print("[R]emove an object / Go to [M]enu / Go to [C]heckout");

                            userInput = screen.Read();

                            //Ta bort object från kundvagn
                            if (userInput is "R" or "r" or "Remove" or "remove")
                            {
                                screen.Print("What would you like to remove?");
                                screen.Center();
                                userInput = Console.ReadLine();
                                for (int i = 0; i < loggedinUser.ShoppingCart.Count; i++)
                                {
                                    if (userInput == loggedinUser.ShoppingCart[i].Name)
                                    {
                                        loggedinUser.ShoppingCart.RemoveAt(i);
                                        break;
                                    }
                                }
                            }

                            //Gå till kassa
                            else if (userInput is "C" or "c" or "Checkout" or "checkout")
                            {
                                screen.NewScreen();
                                screen.Print("Are you sure you want to buy these items? Yes / No");

                                userInput = screen.Read();

                                if (userInput is "ja" or "Ja" or "yes" or "Yes")
                                {
                                    screen.NewScreen();
                                    screen.Print($"You now have {fullPrice}kr in credit-card debt");
                                    Thread.Sleep(1500);
                                    screen.Print("Congratualtions...");
                                    Thread.Sleep(1500);
                                    loggedinUser.ShoppingCart.RemoveRange(0, loggedinUser.ShoppingCart.Count);
                                    break;
                                }
                                
                            }

                            //tillbaka till meny
                            else if (userInput is "M" or "m" or "menu" or "Menu")
                            {
                                break;
                            }
                        }
                    }

                    //skriv ut användar info
                    else if (userInput is "T" or "t" or "ToString" or "tostring")
                    {
                        screen.NewScreen();
                        Console.Write(loggedinUser.ToString());
                        Console.ReadKey();
                    }

                    // ""logga ut""
                    else if (userInput is "Log out" or "log out" or "L" or "l")
                    {
                        break;
                    }
                }
            }
        }


    }
}
