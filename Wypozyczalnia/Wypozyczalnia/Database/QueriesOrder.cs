using System;
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
            var query = from o in db.Zamówienies
                        orderby o.Data_zamówienia ascending
                        select new
                        {
                            o.Data_zamówienia,
                            o.Data_odbioru,
                            o.Zamówienie_ID
                        };
            return Extensions.ToDataTable(query);
        }

        public DataTable SelectOrdersByOrderDate(DateTime orderTime)
        {
            var query = from o in db.Zamówienies
                        where o.Data_zamówienia == orderTime
                        orderby o.Data_zamówienia ascending
                        select new
                        {
                            o.Data_zamówienia,
                            o.Data_odbioru,
                            o.Zamówienie_ID
                        };
            return Extensions.ToDataTable(query);
        }

        public decimal Insert(Zamówienie order)
        {
            db.Zamówienies.InsertOnSubmit(order);
            db.SubmitChanges();
            return order.Zamówienie_ID;
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

        public DataTable SelectPartsByOrder(int orderId)
        {
            var query = from p in db.Częśćs
                        where p.Zamówienie_Zamówienie_ID == orderId
                        select new
                        {
                            p.Część_ID,
                            p.Nazwa,
                            p.Status_części.Status,
                            p.Zamówienie_Zamówienie_ID,
                            p.Cena,
                            p.Statek_Statek_ID
                        };
            return Extensions.ToDataTable(query);
        }

        public DataTable SelectPartsAvailableToOrder()
        {
            var query = from p in db.Częśćs
                        where p.Status_części.Status == "Do zamówienia"
                        select new
                        {
                            p.Część_ID,
                            p.Nazwa,
                            p.Status_części.Status,
                            p.Zamówienie_Zamówienie_ID,
                            p.Cena,
                            p.Statek_Statek_ID
                        };
            return Extensions.ToDataTable(query);
        }
    }
}
