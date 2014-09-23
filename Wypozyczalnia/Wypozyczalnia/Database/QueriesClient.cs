using System.Data;
using System.Linq;

namespace Wypozyczalnia.Database
{
    public class QueriesClient
    {
        public QueriesClient()
        {
        }

        public DataTable SelectAll()
        {
            var query = from c in DatabaseAccess.DB.Klients
                    orderby c.Nazwisko ascending
                    select new
                    {
                        c.Klient_ID,
                        c.Imię,
                        c.Nazwisko,
                        c.Nr_dowodu
                    };

            DataTable dt = Extensions.ToDataTable(query);
            return dt;
        }

        public void Insert(Klient client)
        {
            DatabaseAccess.DB.Klients.InsertOnSubmit(client);
            DatabaseAccess.DB.SubmitChanges();
        }

        public void Edit(Klient c)
        {
            var record = DatabaseAccess.DB.Klients.Single(client => client.Klient_ID == c.Klient_ID);
            record.Imię = c.Imię;
            record.Nazwisko = c.Nazwisko;
            record.Nr_dowodu = c.Nr_dowodu;
            DatabaseAccess.DB.SubmitChanges();
        }

        public void Delete(Klient c)
        {
            var record = DatabaseAccess.DB.Klients.Single(client => client.Klient_ID == c.Klient_ID);
            DatabaseAccess.DB.Klients.DeleteOnSubmit(record);
            DatabaseAccess.DB.SubmitChanges();
        }

        public DataTable SelectBySurname(string surname)
        {
            var query = from c in DatabaseAccess.DB.Klients
                        where c.Nazwisko == surname
                        select new
                        {
                            c.Klient_ID,
                            c.Imię,
                            c.Nazwisko,
                            c.Nr_dowodu
                        };

            DataTable dt = Extensions.ToDataTable(query);
            return dt;
        }
    }
}
