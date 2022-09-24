
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Labb2;


UserBase currentUsers = new UserBase();
currentUsers.OldUser(currentUsers.UserList);
shop theShop = new shop();
theShop.SortiFill(theShop.Sortiment);
Menu Menu = new Menu();


Menu.IntroScreen(currentUsers, theShop);



