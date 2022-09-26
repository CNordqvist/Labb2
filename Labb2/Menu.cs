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
                User loggedinUser = new User();

                string userInput = screen.Read();
                
                
                if (userInput is "register" or "Register")
                {
                    currentUsers.Register(currentUsers.UserList);
                    loggedinUser = currentUsers.LogIn(currentUsers.UserList);
                }
                else if (userInput is "login" or "Login" or "log in" or "Log in")
                {
                   loggedinUser = currentUsers.LogIn(currentUsers.UserList);
                }
                else
                {
                    screen.Print("Unrecognized input, please try again");
                    Thread.Sleep(1500);
                    continue;
                }

                //Meny för att se navigerings-meny
                while (true)
                {
                    screen.NewScreen();
                    Console.Write("Logged in as:" + loggedinUser.Name);
                    
                    screen.Print("vad vill du göra?");
                    screen.Print("[H]andla/ se [K]undvagn / [L]ogga ut");
                    
                    userInput = screen.Read();

                    if
                        (userInput is "Handla" or "handla" or "h" or "H")
                    {
                        while (true)
                        {
                            //Printa sortimentet
                            screen.NewScreen();
                            foreach (var product in theShop.Sortiment)
                            {
                                Console.WriteLine( "  " + product.name +
                                       "   SeK : " + product.price + "\n" +
                                       "   Zimbabwean dollars : " + screen.ZimRate(product.price) +
                                       "   Venezuelan bolivar : " + screen.VenRate(product.price) + "\n\n");
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
                                    if (userInput == product.name)
                                    {
                                        loggedinUser.ShoppingCart.Add(product);
                                        screen.Print(product.name + " has been added to your shopping cart.");
                                        Thread.Sleep(1500);
                                    }
                                }
                            }
                        }
                    }

                    else if
                    (userInput is "Se Kundvagn" or "se kundvagn" or "k" or "K")
                    {
                        

                        while (true)
                        {
                            double fullPrice = 0;
                            int itemsAmount = 0;
                            double sekSaved = 0;
                            double fullZim = 0;
                            double fullVen = 0;

                            //se object användaren har lagt i kundvagn och totalpriset för alla saker. 
                            screen.NewScreen();
                            foreach (var product in loggedinUser.ShoppingCart)
                            {
                                Console.WriteLine(product.name +
                                $"  Sek : " + product.price +
                                $"\nZimbabwean dollars : " + screen.ZimRate(product.price) +
                                $"  Venezuelan bolivar : " + screen.VenRate(product.price) + "\n\n");

                                fullPrice = fullPrice + product.price;
                                itemsAmount++;
                            }

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
                            
                            
                            Console.WriteLine($"{itemsAmount}items. The total price for you is currently " + 
                                         $" Sek : {fullPrice}    " +
                                         $"{Math.Round(sekSaved, 2)}Kr saved via your discount\n" +
                                         $"Zimbabwean dollars :{screen.ZimRate(fullPrice)}   \n" +
                                         $"Venezuelan bolivars :{screen.VenRate(fullPrice)}\n" );


                            screen.Print("What would you like to do?");
                            screen.Print("[T]a bort en vara/Gå till [M]eny/gå till [K]assa");

                            userInput = screen.Read();

                            //Ta bort object från kundvagn
                            if (userInput is "T" or "t" or "ta bort" or "Ta bort")
                            {
                                screen.Print("What would you like to remove?");
                                screen.Center();
                                userInput = Console.ReadLine();
                                for (int i = 0; i < loggedinUser.ShoppingCart.Count; i++)
                                {
                                    if (userInput == loggedinUser.ShoppingCart[i].name)
                                    {
                                        loggedinUser.ShoppingCart.RemoveAt(i);
                                        break;
                                    }
                                }
                            }

                            //Gå till kassa
                            else if (userInput is "K" or "k" or "Kassa" or "kassa")
                            {
                                screen.NewScreen();
                                screen.Print("are you sure you want to buy these items? yes/no");

                                userInput = screen.Read();

                                if (userInput is "ja" or "Ja" or "yes" or "Yes")
                                {
                                    screen.NewScreen();
                                    screen.Print($"du har nu {fullPrice}kr i kreditskuld");
                                    Thread.Sleep(1500);
                                    screen.Print("Grattis...");
                                    Thread.Sleep(1500);
                                    loggedinUser.ShoppingCart.RemoveRange(0, loggedinUser.ShoppingCart.Count);
                                    break;
                                }
                                
                            }

                            //tillbaka till 
                            else if (userInput is "M" or "m" or "meny" or "Meny")
                            {
                                break;
                            }
                        }
                    }

                    else if (userInput is "Logga ut" or "logga ut" or "L" or "l")
                    {
                        break;
                    }
                }
            }
        }


    }
}
