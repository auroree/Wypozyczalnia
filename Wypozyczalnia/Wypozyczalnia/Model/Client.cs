
namespace Wypozyczalnia.Model
{
    public class Client : Person
    {
        public string IdNumber { get; set; }

        public Client()
            : base()
        {

        }

        public Client(string name, string surname, string idNumber)
            : base(name, surname)
        {
            this.IdNumber = idNumber;
        }

        public Client(int id, string name, string surname, string idNumber)
            : base(id, name, surname)
        {
            this.IdNumber = idNumber;
        }
    }
}
