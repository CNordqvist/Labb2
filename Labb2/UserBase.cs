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
    public List<TieredUser> UserList = new List<TieredUser>();


    public List<TieredUser> OldUser(List<TieredUser> UserList)
    {
        TieredUser knatte = new TieredUser() { Name = "Knatte", Password = "123", Tier = 'G' };
        UserList.Add(knatte);

        TieredUser fnatte = new TieredUser() { Name = "Fnatte", Password = "321", Tier = 'S' };
        UserList.Add(fnatte);

        TieredUser tjatte = new TieredUser() { Name = "Tjatte", Password = "213", Tier = 'B' };
        UserList.Add(tjatte);

        return UserList;
    }

    public List<TieredUser> Register(List<TieredUser> currentUser)
    {
        screen.NewScreen();

        TieredUser newUser = new TieredUser();
        var desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var listPath = Path.Combine(desktopDir, "UserText.txt");


        screen.Print("Please enter your desired username");
        var temp = screen.Read();

        //försök för att kolla om användaren är unik
        while (true)
        {
            using StreamReader sr = new StreamReader(listPath);
            {
                var content = listPath;
                if (content.Contains(temp))
                {
                    Console.WriteLine("username is taken, please try another one");
                }
                else
                {
                    break;
                }
            }
        }
        
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
        Thread.Sleep(1000);
        UserList.Add(newUser);

        //skriv den nya användaren till fil
        using StreamWriter sw = new StreamWriter(listPath, true);
        sw.WriteLine(newUser);

        return UserList;
    }

    public User LogIn(List<TieredUser> currentUsers)
    {
        string tempCheck = string.Empty;
        var indexCheck = -1;

        while (true)
        {
            screen.NewScreen();
            screen.Print("what is your username?");
            tempCheck = screen.Read();

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
            System.Threading.Thread.Sleep(500);
        }
        
        //Lösen
        while (true)
        {
            screen.NewScreen();
            screen.Print("and what is your password?");
            tempCheck = screen.Read();

            //tre försök med att matcha lösenordet till inlogget
            if (currentUsers[indexCheck].Password == tempCheck)
            {
                return currentUsers[indexCheck];
            }
            else
            {
                screen.Print("Wrong password ");
                Thread.Sleep(1000);
            }
        }
    }

}