namespace Wypozyczalnia
{
    public static class DatabaseAccess
    {
        private static WypozyczalniaDataClassesDataContext db;

        public static WypozyczalniaDataClassesDataContext DB
        {
            get
            { 
                return db;
            }

            set
            {
                db = value;
            }
        }
    }
}
