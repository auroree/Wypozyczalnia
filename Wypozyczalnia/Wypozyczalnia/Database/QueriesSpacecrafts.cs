using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Wypozyczalnia.Database
{
    public class QueriesSpacecrafts
    {
        public QueriesSpacecrafts()
        {
        }

        public DataTable SelectAll()
        {
            var query = from st in DatabaseAccess.DB.Stateks
                        orderby st.Statek_ID ascending
                        select new
                        {
                            st.Statek_ID,
                            st.Typ_statku.Nazwa_typu,
                            st.Silnik,
                            st.Rok_produkcji,
                            st.Cena_za_dobę
                        };

            DataTable dt = Extensions.ToDataTable(query);
            return dt;
        }
        public DataTable SelectByType(string type)
        {
            var query = from st in DatabaseAccess.DB.Stateks
                        where st.Typ_statku.Nazwa_typu == type
                        select new
                        {
                            st.Statek_ID,
                            st.Typ_statku.Nazwa_typu,
                            st.Silnik,
                            st.Rok_produkcji,
                            st.Cena_za_dobę
                        };
            DataTable dt = Extensions.ToDataTable(query);
            return dt;
        }

        public DataTable SelectByEngine(string name)
        {
            var query = from st in DatabaseAccess.DB.Stateks
                        where st.Silnik == name                 // zmienić?
                        select new
                        {
                            st.Statek_ID,
                            st.Typ_statku.Nazwa_typu,
                            st.Silnik,
                            st.Rok_produkcji,
                            st.Cena_za_dobę
                        };

            DataTable dt = Extensions.ToDataTable(query);
            return dt;
        }

        public List<string> GetAllTypes()
        {
            IEnumerable<Typ_statku> table = DatabaseAccess.DB.Typ_statkus.ToList();
            List<string> list = new List<string>();
            foreach (Typ_statku typ in table)
            {
                list.Add(typ.Nazwa_typu);
            }
            return list;
        }

        public void Insert(Statek spacecraft)
        {
            DatabaseAccess.DB.Stateks.InsertOnSubmit(spacecraft);
            DatabaseAccess.DB.SubmitChanges();
        }

        public void Edit(Statek s)
        {
            var record = DatabaseAccess.DB.Stateks.Single(spacecraft => spacecraft.Statek_ID == s.Statek_ID);
            record.Typ_statku_Typ_statku_ID = s.Typ_statku_Typ_statku_ID;
            record.Silnik = s.Silnik;
            record.Rok_produkcji = s.Rok_produkcji;
            record.Cena_za_dobę = s.Cena_za_dobę;

            DatabaseAccess.DB.SubmitChanges();
        }

        public void Delete(Statek s)
        {
            var record = DatabaseAccess.DB.Stateks.Single(spacecraft => spacecraft.Statek_ID == s.Statek_ID);
            DatabaseAccess.DB.Stateks.DeleteOnSubmit(record);
            DatabaseAccess.DB.SubmitChanges();
        }


        public void InsertType(Typ_statku type)
        {
            DatabaseAccess.DB.Typ_statkus.InsertOnSubmit(type);
            DatabaseAccess.DB.SubmitChanges();
        }

        public void DeleteType(Typ_statku type)
        {

            var record = DatabaseAccess.DB.Typ_statkus.Single(typ => typ.Typ_statku_ID == type.Typ_statku_ID);
            DatabaseAccess.DB.Typ_statkus.DeleteOnSubmit(record);
            DatabaseAccess.DB.SubmitChanges();
        }

        public Typ_statku GetType(string typeName)
        {
            var t = DatabaseAccess.DB.Typ_statkus.Single(typ => typ.Nazwa_typu == typeName);
            return t;
        }
    }
}
