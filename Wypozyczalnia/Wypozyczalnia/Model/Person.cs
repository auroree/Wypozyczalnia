
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
            this.Id = 0;
            this.Name = name;
            this.Surname = surname;
        }

        public Person(int id, string name, string surname)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
        }
    }
}
