using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace Labb2
{
    public class UserBase
    {
        private Global screen = new Global();
        public List<User> userList = new List<User>();
        
        public List<User> OldUser(List<User> userList)
        {
            User knatte = new User() {Name = "Knatte", Password = "123", Tier = 'G'};
            userList.Add(knatte);
            User fnatte = new User() { Name = "Fnatte", Password = "321", Tier = 'S' };
            userList.Add(fnatte);
            User tjatte = new User() { Name = "Tjatte", Password = "666", Tier = 'B' };
            userList.Add(tjatte);
            return userList;
        }

        public List<User> Register()
        {
            screen.NewScreen();
            User newUser = new User();
            
            screen.Print("var god skriv in erat namn");
            newUser.Name = Console.ReadLine();

            Console.WriteLine("välj ett lösenord");
            newUser.Password = Console.ReadLine();

            Console.WriteLine("vilken Kund-nivå har ni?");
            
            while (true)
            {
                string temp = Console.ReadLine();

                if (temp == "Gold" || temp == "gold" || temp == "g" || temp == "G")
                {
                    newUser.Tier = 'G';
                    break;
                }
                else if (temp == "Silver" || temp == "silver" || temp == "s" || temp == "S")
                {
                    newUser.Tier = 'S';
                    break;
                }
                else if (temp == "Bronze" || temp == "bronze" || temp == "b" || temp == "B")
                {
                    newUser.Tier = 'B';
                    break;
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning, var god skriv Gold/Silver/Bronze");
                }
            }
            userList.Add(newUser);
            return userList;
        }

        public User LogIn(List<User> userList)
        {
            return userList[1];
        }

    }

    
    

}