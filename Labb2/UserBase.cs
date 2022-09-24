using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

    public List<User> Register()
    {
        screen.NewScreen();
        User newUser = new User();
            
        screen.Print("Please enter your name");
        newUser.Name = Console.ReadLine();

        screen.Print("Select a password");
        screen.Center();
        string passCheck = Console.ReadLine();
        Console.WriteLine();
        newUser.Password = "111";

        screen.Print("vilken Kund-nivå har ni?");
        
        while (true)
        {
            screen.Center();
            string tempCheck = Console.ReadLine();

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
        UserList.Add(newUser);
        return UserList;
    }

    public User LogIn(List<User> currentUsers)
    {

        var indexCheck = -1;

        while (true)
        {
            screen.NewScreen();
            screen.Print("what is your username?"); 
            screen.Center();
            var tempCheck = Console.ReadLine();
           
            for (int i = 0; i < currentUsers.Count; i++)
            {
                if (currentUsers[i].Name == tempCheck)
                {
                    indexCheck = i;
                }
            }

            if (indexCheck != -1)
            {
                break;
            }
            screen.Print("No User Found, Please try again.");

            
            System.Threading.Thread.Sleep(1500);
        }

        screen.Print("and what is your password?");
        Console.ReadKey();

        return currentUsers[indexCheck];
    }

}