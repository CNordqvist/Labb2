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
        Global _scene = new Global();
        public void IntroScreen(UserBase currentUsers, shop theShop)
        {
            while (true)
            {
                // Logga in eller regga nytt konto meny;
                _scene.NewScreen();
                _scene.PrintRed("Hello and welcome to\n");
                _scene.PrintBanner();
                _scene.Print("Log in or Register a new account?\n\n");
                User loggedinUser = new User();
                _scene.Center();
                string userInput = Console.ReadLine();
                if (userInput is "register" or "Register")
                {
                    currentUsers.Register();
                }
                else if (userInput is "login" or "Login" or "log in" or "Log in")
                {
                   loggedinUser = currentUsers.LogIn(currentUsers.UserList);
                }
                else
                {
                    _scene.Print("Unrecognized input, please try again");
                    Thread.Sleep(1500);
                    continue;
                }

                //Meny för att se navigerings-meny
                while (true)
                {
                    _scene.NewScreen();
                    Console.Write("Logged in as:" + loggedinUser.Name);
                    
                    _scene.Print("vad vill du göra?");
                    _scene.Print("[H]andla/ se [K]undvagn / [L]ogga ut");
                    _scene.Center();
                    userInput = Console.ReadLine();

                    if
                        (userInput is "Handla" or "handla" or "h" or "H")
                    {
                        while (true)
                        {
                            //printa sortimentet
                            _scene.NewScreen();
                            foreach (var product in theShop.Sortiment)
                            {
                                Console.WriteLine(product.name +
                                       "   SeK : " + product.price +
                                        "\nZimbabwean dollars : " + product.priceZim +
                                       "   Venezuelan bolivar : " + product.priceVen + "\n\n");
                            }

                            //lägg till i användarens shoppingCart
                            _scene.Print("What would you like to buy? [M] for menu");
                            userInput = Console.ReadLine();
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
                                        _scene.Print(product.name + "has been added to your shoppingcart.");
                                        Thread.Sleep(1500);
                                    }
                                }
                            }
                        }
                    }

                    else if
                    (userInput is "Se Kundvagn" or "se kundvagn" or "k" or "K")
                    {
                        _scene.NewScreen();
                        foreach (var product in loggedinUser.ShoppingCart)
                        {
                            Console.WriteLine(product.name +
                                     "   SeK : " + product.price +
                                      "\nZimbabwean dollars : " + product.priceZim +
                                     "   Venezuelan bolivar : " + product.priceVen + "\n\n");
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
