using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    namespace Model
    {
        class Client : Person
        {
            public int ClientNumber { get; set; }

            public Client()
                : base()
            {

            }

            public Client(int id, string name, string surname, int yearOfBirth, int clientNumber)
                : base(id, name, surname, yearOfBirth)
            {
                ClientNumber = clientNumber;
            }
        }
    }
}
