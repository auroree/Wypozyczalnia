using System.Linq;
using System.Data;

namespace Wypozyczalnia.Database
{
    class QueriesOrder
    {
        WypozyczalniaDataClassesDataContext db;

        public QueriesOrder()
        {
            db = new WypozyczalniaDataClassesDataContext();
        }

        public QueriesOrder(WypozyczalniaDataClassesDataContext dbContext)
        {
            db = dbContext;
        }

        public DataTable SelectAll()
        {
            var query = from e in db.Zamówienies
                        orderby e.Data_zamówienia ascending
                        select new
                        {
                            e.Data_zamówienia,
                            e.Data_odbioru,
                            e.Zamówienie_ID
                        };
            return Extensions.ToDataTable(query);
        }

        public void Insert(Zamówienie order)
        {
            db.Zamówienies.InsertOnSubmit(order);
            db.SubmitChanges();
        }

        public void Edit(Zamówienie o)
        {
            var record = db.Zamówienies.Single(order => order.Zamówienie_ID == o.Zamówienie_ID);
            record.Data_zamówienia = o.Data_zamówienia;
            record.Data_odbioru = o.Data_odbioru;
            db.SubmitChanges();
        }

        public void Delete(Zamówienie o)
        {
            var record = db.Zamówienies.Single(order => order.Zamówienie_ID == o.Zamówienie_ID);
            db.Zamówienies.DeleteOnSubmit(record);
            db.SubmitChanges();
        }
    }
}
