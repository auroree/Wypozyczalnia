using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia.Model
{
    public class Employee : Person
    {
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public float Salary { get; set; }
        public string Function { get; set; }

        public Employee()
            : base()
        {

        }

        public Employee(string name, string surname,
            DateTime dateOfBirth, string placeOfBirth, float salary, string function)
            : base(name, surname)
        {
            this.DateOfBirth = dateOfBirth;
            this.PlaceOfBirth = placeOfBirth;
            this.Salary = salary;
            this.Function = function;
        }

        public Employee(int id, string name, string surname,
            DateTime dateOfBirth, string placeOfBirth, float salary, string function)
            : base(id, name, surname)
        {
            this.DateOfBirth = dateOfBirth;
            this.PlaceOfBirth = placeOfBirth;
            this.Salary = salary;
            this.Function = function;
        }
    }
}
