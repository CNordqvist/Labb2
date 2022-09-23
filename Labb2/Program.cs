
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Labb2;

Global scene = new Global();
UserBase currentUsers = new UserBase();
currentUsers.OldUser(currentUsers.userList);

introScreen();
//userid ==

foreach (var User in currentUsers.userList)
{
    scene.Print(User.Name);
}
Console.ReadKey();


//return userID after login
void introScreen()
{
    scene.NewScreen();

    scene.Print("Hello and welcome to the \n");
    scene.PrintRed("Rogue Trader Emporium \n \n");
    scene.Print("Log in or Register a new account? \n \n");

    scene.Center();
    string login = Console.ReadLine();
    if (login == "register" || login == "Register")
    {
        currentUsers.Register();
    } else if (login == "login" || login == "Login" || login == "log in" || login == "Log in")
    {
        scene.Print("what is your username?");

        scene.Print("and what is your password?");
    }
}

