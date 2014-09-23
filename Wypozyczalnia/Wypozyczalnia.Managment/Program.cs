using System;
using Wypozyczalnia.Database;

namespace Wypozyczalnia.Managment
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string newLogin, newPassword, newPermission;
                int permission = 0;
                do
                {
                    Console.Write("Uzytkownik: ");
                    newLogin = Console.ReadLine();
                    Console.Write("Haslo: ");
                    newPassword = Console.ReadLine();
                    Console.Write("Kod uprawnien: ");
                    newPermission = Console.ReadLine();
                    if (!int.TryParse(newPermission, out permission))
                    {
                        Console.WriteLine("Kod uprawnien musi byc liczba.");
                    }
                }
                while (newLogin == string.Empty || newPassword == string.Empty || permission == 0);

                LoginClassesDataContext dbin = new LoginClassesDataContext(
                    DatabaseSettings.CreateConnectionString(
                    "hania-laptop\\sqlexpress",
                    "Wypozyczalnia",
                    "sa", 
                    "Admin1"));

                Użytkownik u = new Użytkownik();
                u.Nazwa = newLogin;
                u.Hasło = dbin.HashMD5(newPassword);
                u.Uprawnienia_Uprawnienia_ID = permission;
                dbin.Użytkowniks.InsertOnSubmit(u);
                dbin.SubmitChanges();

                Console.WriteLine("Dodano uzytkownika " + newLogin);
            }
        }
    }
}
