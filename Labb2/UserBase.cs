using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Labb2;

public class UserBase
{
    private Global screen = new Global();
    public List<User> UserList = new List<User>();
        
    public List<User> OldUser(List<User> UserList)
    {
        User knatte = new User() {Name = "Knatte", Password = "123", Tier = 'G'};
        UserList.Add(knatte);

        User fnatte = new User() { Name = "Fnatte", Password = "321", Tier = 'S' };
        UserList.Add(fnatte);

        User tjatte = new User() { Name = "Tjatte", Password = "666", Tier = 'B' };
        UserList.Add(tjatte);

        return UserList;
    }

    public List<User> Register(List<User> currentUser)
    {
        screen.NewScreen();
        
        User newUser = new User();

        screen.Print("Please enter your name");

        var temp = screen.Read();
        foreach (var VARIABLE in currentUser)
        {
            //sök igenom currentUser.name för att se till att användarna är unika
        }

        newUser.Name = screen.Read();


        while (true) {

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
            string tempCheck = screen.Read();

            if (tempCheck is "Gold" or "gold" or "g" or "G")
            {
                newUser.Tier = 'G';
                break;
            }
            else if (tempCheck is "Silver" or "silver" or "s" or "S")
            {
                newUser.Tier = 'S';
                break;
            }
            else if (tempCheck is "Bronze" or "bronze" or "b" or "B")
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
        Thread.Sleep(1500);
        UserList.Add(newUser);
        return UserList;
    }

    public User LogIn(List<User> currentUsers)
    {
        string tempCheck = "";
        var indexCheck = -1;

        //användare
        while (true)
        {
            screen.NewScreen();
            screen.Print("what is your username?"); 
            screen.Center();
            tempCheck = Console.ReadLine();

            //kolla om användaren finns
            for (int i = 0; i < currentUsers.Count; i++)
            {
                if (currentUsers[i].Name == tempCheck)
                {
                    indexCheck = i;
                }
            }

            //om användaren finns, bryt ut ur loopen
            if (indexCheck != -1)
            {
                break;
            }

            screen.Print("No User Found, Please try again.");
            System.Threading.Thread.Sleep(1500);
        }
        int passCheck = 3;
        //Lösen
        while (true) 
        {
            screen.NewScreen();
            screen.Print("and what is your password?");
            screen.Center();
            
            tempCheck = Console.ReadLine();

            //tre försök med att matcha lösenordet till inlogget
            if (currentUsers[indexCheck].Password == tempCheck)
            {
                return currentUsers[indexCheck];
            }
            else if (passCheck == 0)
            {
                return null;
            }
            else
            {
                screen.Print("Wrong password " + passCheck + " attempts left");
                passCheck--;
                Thread.Sleep(1500);
            }
        }
    }

}