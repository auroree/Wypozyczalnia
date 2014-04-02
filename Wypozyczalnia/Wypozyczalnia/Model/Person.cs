using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    namespace Model
    {
        class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public int YearOfBirth { get; set; }

            public Person()
            {
            }

            public Person(int id, string name, string surname, int yearOfBirth)
            {
                Id = id;
                Name = name;
                Surname = surname;
                YearOfBirth = yearOfBirth;
            }

        }
    }
}
