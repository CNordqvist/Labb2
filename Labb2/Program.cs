
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Labb2;

UserBase currentUsers = new UserBase();
currentUsers.OldUser(currentUsers.UserList);
shop theShop = new shop();
theShop.SortiFill(theShop.Sortiment);
Menu Menu = new Menu();

var desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var listPath = Path.Combine(desktopDir, "UserText.txt");

if (!File.Exists(listPath))
{
    using StreamWriter sw = new StreamWriter(listPath);

    foreach (var TieredUser in currentUsers.UserList)
    {
        sw.WriteLine(TieredUser);
    }
}


Menu.IntroScreen(currentUsers, theShop);


