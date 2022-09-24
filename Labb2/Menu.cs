using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class Menu
    {
        Global scene = new Global();
        public void IntroScreen(UserBase currentUsers, shop theShop)
        {
            while (true)
            {
                scene.NewScreen();

                scene.Print("Hello and welcome to\n");
                scene.PrintBanner();
                /* scene.PrintRed("THE SHOP\n \n"); */
                scene.Print("Log in or Register a new account?\n\n");

                scene.Center();
                string login = Console.ReadLine();
                if (login is "register" or "Register")
                {
                    currentUsers.Register();
                }
                else if (login is "login" or "Login" or "log in" or "Log in")
                {
                    currentUsers.LogIn(currentUsers.UserList);
                }

                foreach (var User in currentUsers.UserList)
                {
                    scene.Print(User.Name);
                }
            }
        }


    }
}
