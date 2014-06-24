using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Wypozyczalnia.Database
{
    public class QueriesReservation
    {
        WypozyczalniaDataClassesDataContext db;

        public QueriesReservation()
        {
            db = new WypozyczalniaDataClassesDataContext();
        }

        public QueriesReservation(WypozyczalniaDataClassesDataContext dbContext)
        {
            db = dbContext;
        }

        /*Pobrane wszystkich danych o rezerwacjach*/
        public DataTable SelectAll()
        {
            var query = from r in db.Rezerwacjas
                        join c in db.Klients on r.Klient_Klient_ID equals c.Klient_ID
                        join s in db.Stateks on r.Statek_Statek_ID equals s.Statek_ID
                        join t in db.Typ_statkus on s.Typ_statku_Typ_statku_ID equals t.Typ_statku_ID

                        select new
                        {
                            r.Rezerwacja_ID,
                            Imie_Klienta = c.Imię,
                            Nazwisko_Klienta = c.Nazwisko,
                            Typ_Statku = t.Nazwa_typu,
                            Cena_za_dobe = s.Cena_za_dobę,
                            r.Data_wypożyczenia,
                            r.Data_zwrotu
                        };

            DataTable dt = Extensions.ToDataTable(query);
            return dt;
        }


        /*Wyszukanie rezerwacji po nazwisku*/
        public DataTable SelectBySurname(string surname)
        {

            var query = from r in db.Rezerwacjas
                        join c in db.Klients on r.Klient_Klient_ID equals c.Klient_ID
                        join s in db.Stateks on r.Statek_Statek_ID equals s.Statek_ID
                        join t in db.Typ_statkus on s.Typ_statku_Typ_statku_ID equals t.Typ_statku_ID
                        join p in db.pilotujes on r.Statek_Statek_ID equals p.Rezerwacja_Rezerwacja_ID
                        join e in db.Pracowniks on p.Pracownik_Pracownik_ID equals e.Pracownik_ID
                        where c.Nazwisko == surname
                        select new
                        {
                            r.Rezerwacja_ID,
                            Imie_Klienta = c.Imię,
                            Nazwisko_Klienta = c.Nazwisko,
                            Pracownik_Nazwisko = e.Nazwisko,
                            Typ_Statku = t.Nazwa_typu,
                            Cena_za_dobe = s.Cena_za_dobę,
                            r.Data_wypożyczenia,
                            r.Data_zwrotu
                        };

            DataTable dt = Extensions.ToDataTable(query);
            return dt;
        }


        /*Wyszukanie rezerwacji po id*/
        public DataTable SelectById(int id)
        {

            var query = from r in db.Rezerwacjas
                        join c in db.Klients on r.Klient_Klient_ID equals c.Klient_ID
                        join s in db.Stateks on r.Statek_Statek_ID equals s.Statek_ID
                        join t in db.Typ_statkus on s.Typ_statku_Typ_statku_ID equals t.Typ_statku_ID
                        where r.Klient_Klient_ID == id
                        select new
                        {
                            r.Rezerwacja_ID,
                            Imie_Klienta = c.Imię,
                            Nazwisko_Klienta = c.Nazwisko,
                            Typ_Statku = t.Nazwa_typu,
                            Cena_za_dobe = s.Cena_za_dobę,
                            r.Data_wypożyczenia,
                            r.Data_zwrotu
                        };

            DataTable dt = Extensions.ToDataTable(query);
            return dt;
        }

        /*Wykasowanie danych o rezerwacji*/
        public void Delete(int id)
        {
            var toRemove = from p in db.pilotujes
                           where p.Rezerwacja_Rezerwacja_ID == id
                           select p;

            var elements = toRemove.ToList();

            foreach (var element in elements)
                db.pilotujes.DeleteOnSubmit(element);

            var record = db.Rezerwacjas.Single(reservation => reservation.Rezerwacja_ID == id);
            db.Rezerwacjas.DeleteOnSubmit(record);
            db.SubmitChanges();
        }

        /*Wyszukanie pracownikow powiazanych z rezerwacja*/
        public DataTable SelectReservationEmployee(int id)
        {
            var query = from p in db.pilotujes
                        join e in db.Pracowniks on p.Pracownik_Pracownik_ID equals e.Pracownik_ID
                        where p.Rezerwacja_Rezerwacja_ID == id
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

        /*Wyszukanie pracownikow dostepnych w terminie od daty wypozyczenia do daty zwrotu*/
        public DataTable SelectEmployeesByDate(DateTime HireDate, DateTime? DueDate = null)
        {
            DataTable dt;
            if (DueDate == null)
            {
                var query = (from e in db.Pracowniks
                             join p in db.pilotujes on e.Pracownik_ID equals p.Pracownik_Pracownik_ID into joinedEmpEmpty
                             from p in joinedEmpEmpty.DefaultIfEmpty()
                             join r in db.Rezerwacjas on p.Rezerwacja_Rezerwacja_ID equals r.Rezerwacja_ID into joinedResEmpty
                             from r in joinedResEmpty.DefaultIfEmpty()
                             where (r.Rezerwacja_ID == null) || (
                                    (!((from rr in db.Rezerwacjas
                                        join pp in db.pilotujes on rr.Rezerwacja_ID equals pp.Rezerwacja_Rezerwacja_ID
                                        where ((rr.Data_zwrotu > HireDate) || (rr.Data_wypożyczenia > HireDate) || (rr.Data_zwrotu == null))
                                        select pp.Pracownik_Pracownik_ID).Contains(e.Pracownik_ID))))
                             select new
                             {
                                 e.Pracownik_ID,
                                 e.Imię,
                                 e.Nazwisko,
                                 e.Data_urodzenia,
                                 e.Miejsce_urodzenia,
                                 e.Pensja,
                                 e.Funkcja.Nazwa_funkcji
                             }).Distinct();
                dt = Extensions.ToDataTable(query);
            }
            else
            {
                var query = (from e in db.Pracowniks
                             join p in db.pilotujes on e.Pracownik_ID equals p.Pracownik_Pracownik_ID into joinedEmpEmpty
                             from p in joinedEmpEmpty.DefaultIfEmpty()
                             join r in db.Rezerwacjas on p.Rezerwacja_Rezerwacja_ID equals r.Rezerwacja_ID into joinedResEmpty
                             from r in joinedResEmpty.DefaultIfEmpty()
                             where (r.Rezerwacja_ID == null) || (((from rr in db.Rezerwacjas
                                                                   where ((rr.Data_wypożyczenia > HireDate) && (rr.Data_wypożyczenia > DueDate)) ||
                                                                         ((rr.Data_zwrotu < HireDate) && (rr.Data_zwrotu < DueDate))
                                                                   select rr.Rezerwacja_ID).Contains(r.Rezerwacja_ID)) && r.Data_zwrotu != null)
                             select new
                             {
                                 e.Pracownik_ID,
                                 e.Imię,
                                 e.Nazwisko,
                                 e.Data_urodzenia,
                                 e.Miejsce_urodzenia,
                                 e.Pensja,
                                 e.Funkcja.Nazwa_funkcji
                             }).Distinct();
                dt = Extensions.ToDataTable(query);
            }

            return dt;
        }

        /*Wyszukanie pracownikow dostepnych w danym terminie lub powiazanychz  dana rezewacja*/
        public DataTable SelectEmployeesByDate(decimal id, DateTime HireDate, DateTime? DueDate = null)
        {
            DataTable dt;
            if (DueDate == null)
            {
                var query = (from e in db.Pracowniks
                             join p in db.pilotujes on e.Pracownik_ID equals p.Pracownik_Pracownik_ID into joinedEmpEmpty
                             from p in joinedEmpEmpty.DefaultIfEmpty()
                             join r in db.Rezerwacjas on p.Rezerwacja_Rezerwacja_ID equals r.Rezerwacja_ID into joinedResEmpty
                             from r in joinedResEmpty.DefaultIfEmpty()
                             where (r.Rezerwacja_ID == null) || (
                                    (!((from rr in db.Rezerwacjas
                                        join pp in db.pilotujes on rr.Rezerwacja_ID equals pp.Rezerwacja_Rezerwacja_ID
                                        where ((rr.Data_zwrotu > HireDate) || (rr.Data_wypożyczenia > HireDate) || (rr.Data_zwrotu == null))
                                        select pp.Pracownik_Pracownik_ID).Contains(e.Pracownik_ID)))) || (r.Rezerwacja_ID == id)
                             select new
                             {
                                 e.Pracownik_ID,
                                 e.Imię,
                                 e.Nazwisko,
                                 e.Data_urodzenia,
                                 e.Miejsce_urodzenia,
                                 e.Pensja,
                                 e.Funkcja.Nazwa_funkcji
                             }).Distinct();
                dt = Extensions.ToDataTable(query);
            }
            else
            {
                var query = (from e in db.Pracowniks
                             join p in db.pilotujes on e.Pracownik_ID equals p.Pracownik_Pracownik_ID into joinedEmpEmpty
                             from p in joinedEmpEmpty.DefaultIfEmpty()
                             join r in db.Rezerwacjas on p.Rezerwacja_Rezerwacja_ID equals r.Rezerwacja_ID into joinedResEmpty
                             from r in joinedResEmpty.DefaultIfEmpty()
                             where (r.Rezerwacja_ID == null) || (((from rr in db.Rezerwacjas
                                                                   where ((rr.Data_wypożyczenia > HireDate) && (rr.Data_wypożyczenia > DueDate)) ||
                                                                         ((rr.Data_zwrotu < HireDate) && (rr.Data_zwrotu < DueDate))
                                                                   select rr.Rezerwacja_ID).Contains(r.Rezerwacja_ID)) && r.Data_zwrotu != null) || (r.Rezerwacja_ID == id)
                             select new
                             {
                                 e.Pracownik_ID,
                                 e.Imię,
                                 e.Nazwisko,
                                 e.Data_urodzenia,
                                 e.Miejsce_urodzenia,
                                 e.Pensja,
                                 e.Funkcja.Nazwa_funkcji
                             }).Distinct();
                dt = Extensions.ToDataTable(query);
            }

            return dt;
        }

        /*Wyszukanie pojedynczego klienta*/
        public DataTable SelectSingleClient(int id)
        {
            var query = from r in db.Rezerwacjas
                        join c in db.Klients on r.Klient_Klient_ID equals c.Klient_ID
                        where r.Rezerwacja_ID == id
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

        /*Wyszukanie pojedynczego statku*/
        public DataTable SelectSingleShip(int id)
        {
            var query = from r in db.Rezerwacjas
                        join s in db.Stateks on r.Klient_Klient_ID equals s.Statek_ID
                        join t in db.Typ_statkus on s.Typ_statku_Typ_statku_ID equals t.Typ_statku_ID
                        where r.Rezerwacja_ID == id
                        select new
                        {
                            s.Statek_ID,
                            s.Rok_produkcji,
                            s.Silnik,
                            t.Nazwa_typu
                        };
            DataTable dt = Extensions.ToDataTable(query);
            return dt;
        }

        /*Wyszukanie statkow dostepnych w terminie od daty wypozyczenia do daty zwrotu*/
        public DataTable SelectShipsByDate(DateTime HireDate, DateTime? DueDate = null)
        {
            DataTable dt;
            if (DueDate == null)
            {
                var query = (from s in db.Stateks
                             join r in db.Rezerwacjas on s.Statek_ID equals r.Statek_Statek_ID into joinedShipsEmpty
                             from r in joinedShipsEmpty.DefaultIfEmpty()
                             join t in db.Typ_statkus on s.Typ_statku_Typ_statku_ID equals t.Typ_statku_ID
                             where (r.Rezerwacja_ID == null) || ((!(from rr in db.Rezerwacjas where ((rr.Data_zwrotu > HireDate) || (rr.Data_wypożyczenia > HireDate) || (rr.Data_zwrotu == null)) select rr.Statek_Statek_ID).Contains(s.Statek_ID)))
                             select new
                             {
                                 s.Statek_ID,
                                 s.Rok_produkcji,
                                 s.Silnik,
                                 t.Nazwa_typu
                             }).Distinct();
                dt = Extensions.ToDataTable(query);
            }
            else
            {
                var query = (from s in db.Stateks
                             join r in db.Rezerwacjas on s.Statek_ID equals r.Statek_Statek_ID into joinedShipsEmpty
                             from r in joinedShipsEmpty.DefaultIfEmpty()
                             join t in db.Typ_statkus on s.Typ_statku_Typ_statku_ID equals t.Typ_statku_ID
                             where (r.Rezerwacja_ID == null) || (((from rr in db.Rezerwacjas
                                                                   where ((rr.Data_wypożyczenia > HireDate) && (rr.Data_wypożyczenia > DueDate)) ||
                                                                         ((rr.Data_zwrotu < HireDate) && (rr.Data_zwrotu < DueDate))
                                                                   select rr.Rezerwacja_ID).Contains(r.Rezerwacja_ID)) && r.Data_zwrotu != null)
                             select new
                             {
                                 s.Statek_ID,
                                 s.Rok_produkcji,
                                 s.Silnik,
                                 t.Nazwa_typu
                             });
                dt = Extensions.ToDataTable(query);
            }

            return dt;
        }

        /*Wyszukanie statkow dostepnych w danym terminie lub przypisanych do danej rezerwacji*/
        public DataTable SelectShipsByDate(decimal id, DateTime HireDate, DateTime? DueDate = null)
        {
            DataTable dt;
            if (DueDate == null)
            {
                var query = (from s in db.Stateks
                             join r in db.Rezerwacjas on s.Statek_ID equals r.Statek_Statek_ID into joinedShipsEmpty
                             from r in joinedShipsEmpty.DefaultIfEmpty()
                             join t in db.Typ_statkus on s.Typ_statku_Typ_statku_ID equals t.Typ_statku_ID
                             where (r.Rezerwacja_ID == null) || ((!(from rr in db.Rezerwacjas where ((rr.Data_zwrotu > HireDate) || (rr.Data_wypożyczenia > HireDate) || (rr.Data_zwrotu == null)) select rr.Statek_Statek_ID).Contains(s.Statek_ID))) || (r.Rezerwacja_ID == id)
                             select new
                             {
                                 s.Statek_ID,
                                 s.Rok_produkcji,
                                 s.Silnik,
                                 t.Nazwa_typu
                             }).Distinct();
                dt = Extensions.ToDataTable(query);
            }
            else
            {
                var query = (from s in db.Stateks
                             join r in db.Rezerwacjas on s.Statek_ID equals r.Statek_Statek_ID into joinedShipsEmpty
                             from r in joinedShipsEmpty.DefaultIfEmpty()
                             join t in db.Typ_statkus on s.Typ_statku_Typ_statku_ID equals t.Typ_statku_ID
                             where (r.Rezerwacja_ID == null) || (((from rr in db.Rezerwacjas
                                                                   where ((rr.Data_wypożyczenia > HireDate) && (rr.Data_wypożyczenia > DueDate)) ||
                                                                         ((rr.Data_zwrotu < HireDate) && (rr.Data_zwrotu < DueDate))
                                                                   select rr.Rezerwacja_ID).Contains(r.Rezerwacja_ID)) && r.Data_zwrotu != null) || (r.Rezerwacja_ID == id)
                             select new
                             {
                                 s.Statek_ID,
                                 s.Rok_produkcji,
                                 s.Silnik,
                                 t.Nazwa_typu
                             });
                dt = Extensions.ToDataTable(query);
            }

            return dt;
        }

        /*Wyszukanie wszystkich klientow z wyjatkiem jednego*/
        public DataTable SelectAllWithoutSingle(int id)
        {
            var query = from c in db.Klients
                        join r in db.Rezerwacjas on c.Klient_ID equals r.Klient_Klient_ID into empty
                        from r in empty.DefaultIfEmpty()
                        where (r.Rezerwacja_ID != id) || (r.Klient_Klient_ID == null)
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

        /*wstawienie rezerwacji*/
        public decimal InsertReservation(Rezerwacja r)
        {
            db.Rezerwacjas.InsertOnSubmit(r);
            db.SubmitChanges();
            return r.Rezerwacja_ID;
        }

        /*edycja rezerwacji*/
        public decimal EditReservation(Rezerwacja r)
        {
            var record = db.Rezerwacjas.Single(reservation => reservation.Rezerwacja_ID == r.Rezerwacja_ID);
            record.Data_wypożyczenia = r.Data_wypożyczenia;
            record.Data_zwrotu = r.Data_zwrotu;
            record.Klient_Klient_ID = r.Klient_Klient_ID;
            record.Statek_Statek_ID = r.Statek_Statek_ID;

            db.SubmitChanges();
            return r.Rezerwacja_ID;
        }

        /*Wykasowanie pracownikow zwiazanych z rezerwacja*/
        public void DeleteReservtionEmployees(int id)
        {
            var toRemove = from p in db.pilotujes
                           where p.Rezerwacja_Rezerwacja_ID == id
                           select p;

            var elements = toRemove.ToList();

            foreach (var element in elements)
                db.pilotujes.DeleteOnSubmit(element);

            db.SubmitChanges();
        }

        /*Wstawienie pracownika powiązanego z rezerwcja*/
        public void InsertReservationEmployee(pilotuje p)
        {
            db.pilotujes.InsertOnSubmit(p);
            db.SubmitChanges();
        }
    }
}
