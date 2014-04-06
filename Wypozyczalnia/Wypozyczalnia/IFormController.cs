
using Wypozyczalnia.Database;

namespace Wypozyczalnia
{
    public interface IFormController
    {
        void SetConnection(DatabaseConnection dc);
        void Confirm();
        void Add();
        void Edit();
        void Delete();
    }
}
