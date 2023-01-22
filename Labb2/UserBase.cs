using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace Labb2;

public class UserBase
{
    private Global screen = new Global();


    public void Register(List<User> allUsers)
    {
        screen.NewScreen();
        User newUser = new();


        screen.Print("Please enter your desired username");
        var temp = screen.Read();

        
        newUser.Name = temp;

        while (true)
        {
            screen.Print("Select a password");

            string passCheck = screen.Read();
            Console.WriteLine();
            screen.Print("Please reconfirm your password");

            string passcheck2 = screen.Read();
            if (passCheck == passcheck2)
            {
                newUser.Password = passCheck;
                break;
            }
        }

        screen.Print("Vilken Kund-nivå har ni?");

        while (true)
        {
            string tempCheck = screen.Read().ToLower();

            if (tempCheck is "gold" or "g")
            {
                newUser.Tier = 'G';
                break;
            }
            else if (tempCheck is "silver" or "s")
            {
                newUser.Tier = 'S';
                break;
            }
            else if (tempCheck is "bronze" or "b")
            {
                newUser.Tier = 'B';
                break;
            }
            else
            {
                screen.Print("Felaktig inmatning, var god skriv Gold/Silver/Bronze");
            }
        }
        screen.Print($" {newUser.Name} har nu blivigt registrerad.");

        Thread.Sleep(1000);
        
    }

    public User LogIn(List<User> allUsers)
    {
        string tempCheck = string.Empty;
        var userSearch = new User();

        while (true)
        {
            screen.NewScreen();
            screen.Print("what is your username?");
            tempCheck = screen.Read();
            userSearch = allUsers.Find(x => x.Name == tempCheck);

            if (userSearch == null)
            {
                screen.Print("No User Found, Please try again.");
                System.Threading.Thread.Sleep(500);
            }
            else
            {
                break;
            }
        }
        
        //Lösen
        while (true)
        {
            screen.NewScreen();
            screen.Print("and what is your password?");
            tempCheck = screen.Read();

            if (userSearch.Password == tempCheck)
            {
                return userSearch;
            }
            else
            {
                screen.Print("Wrong password");
                Thread.Sleep(1000);
            }
        }
    }

}