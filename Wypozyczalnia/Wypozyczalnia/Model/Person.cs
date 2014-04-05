
namespace Wypozyczalnia.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Person()
        {
        }

        public Person(string name, string surname)
        {
            Id = 0;
            Name = name;
            Surname = surname;
        }

        public Person(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
    }
}
