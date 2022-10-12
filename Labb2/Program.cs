
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
else
{
    using StreamReader sr = new StreamReader(listPath);

    var checkList = sr.ReadToEnd().Split("!");
    currentUsers.UserList.Clear();

    for (int i = 0; i < checkList.Length - 1; i++)
    {
        var temp = checkList[i].Split("&");
        var temp2 = temp[1].Split("?");

        TieredUser newTieredUser = new TieredUser()
        {
            Name = temp[0].Replace("N:", "").Replace("\r\n", ""),
            Password = temp2[0].Replace("PW:", ""),
            Tier = char.Parse(temp2[1].Replace("T:", ""))
        };
        currentUsers.UserList.Add(newTieredUser);
    }

}

Menu.IntroScreen(currentUsers, theShop);



