using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Wypozyczalnia.Database
{
    public class QueriesEmployee
    {
        public QueriesEmployee()
        {
        }

        public DataTable SelectAll()
        {
            var query = from e in DatabaseAccess.DB.Pracowniks
                        orderby e.Nazwisko ascending
                        select new
                        {
                            e.Pracownik_ID,
                            e.Imię,
                            e.Nazwisko,
                            e.Data_urodzenia,
                            e.Miejsce_urodzenia,
                            e.Pensja,
                            e.Funkcja.Nazwa_funkcji
                        };

            DataTable dt = Extensions.ToDataTable(query);
            return dt;
        }

        public void Insert(Pracownik employee)
        {
            DatabaseAccess.DB.Pracowniks.InsertOnSubmit(employee);
            DatabaseAccess.DB.SubmitChanges();
        }

        public void Edit(Pracownik e)
        {
            var record = DatabaseAccess.DB.Pracowniks.Single(employee => employee.Pracownik_ID == e.Pracownik_ID);
            record.Imię = e.Imię;
            record.Nazwisko = e.Nazwisko;
            record.Data_urodzenia = e.Data_urodzenia;
            record.Miejsce_urodzenia = e.Miejsce_urodzenia;
            record.Pensja = e.Pensja;
            record.Funkcja_Funkcja_ID = e.Funkcja_Funkcja_ID;
            DatabaseAccess.DB.SubmitChanges();
        }

        public void Delete(Pracownik e)
        {
            var record = DatabaseAccess.DB.Pracowniks.Single(employee => employee.Pracownik_ID == e.Pracownik_ID);
            DatabaseAccess.DB.Pracowniks.DeleteOnSubmit(record);
            DatabaseAccess.DB.SubmitChanges();
        }

        public DataTable SelectBySurname(string surname)
        {
            var query = from e in DatabaseAccess.DB.Pracowniks
                        where e.Nazwisko == surname
                        select new
                        {
                            e.Pracownik_ID,
                            e.Imię,
                            e.Nazwisko,
                            e.Data_urodzenia,
                            e.Miejsce_urodzenia,
                            e.Pensja,
                            e.Funkcja.Nazwa_funkcji
                        };
            DataTable dt = Extensions.ToDataTable(query);
            return dt;
        }

        public DataTable SelectByFunction(string function)
        {
            var query = from e in DatabaseAccess.DB.Pracowniks
                        where e.Funkcja.Nazwa_funkcji == function
                        select new
                        {
                            e.Pracownik_ID,
                            e.Imię,
                            e.Nazwisko,
                            e.Data_urodzenia,
                            e.Miejsce_urodzenia,
                            e.Pensja,
                            e.Funkcja.Nazwa_funkcji
                        };
            DataTable dt = Extensions.ToDataTable(query);
            return dt;
        }

        public Funkcja GetFunction(string functionName)
        {
            var f = DatabaseAccess.DB.Funkcjas.Single(funkcja => funkcja.Nazwa_funkcji == functionName);
            return f;
        }

        public List<string> GetAllFunctions()
        {
            IEnumerable<Funkcja> table = DatabaseAccess.DB.Funkcjas.ToList();
            List<string> list = new List<string>();
            foreach (Funkcja f in table) 
            {
                list.Add(f.Nazwa_funkcji);
            }
            return list;
        }

    }
}