using System.Data;
using System.Data.SqlClient;
using Wypozyczalnia.Model;

namespace Wypozyczalnia.Database
{
    public class DBClient
    {
        public DBClient()
        {

        }

        public static SqlCommand InsertQuery(Client client)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "INSERT INTO [Klient] ([Imię], [Nazwisko], [Nr_dowodu]) " +
                "VALUES(@Name, @Surname, @IdNumber)";

            // wersja z obcinaniem dlugosci parametru
            SqlParameter param;
            param = new SqlParameter("@Name", SqlDbType.VarChar, 50);
            param.Value = client.Name;
            command.Parameters.Add(param);
            param = new SqlParameter("@Surname", SqlDbType.VarChar, 50);
            param.Value = client.Surname;
            command.Parameters.Add(param);
            param = new SqlParameter("@IdNumber", SqlDbType.VarChar, 20);
            param.Value = client.IdNumber;
            command.Parameters.Add(param);
            
            return command;
        }

        public static SqlCommand UpdateQuery(Client client)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE [Klient] SET [Imię] = @Name, [Nazwisko] = @Surname, [Nr_dowodu] = @IdNumber " +
                "WHERE [Klient_ID] = @Id";

            // wersja z obcinaniem dlugosci parametru
            SqlParameter param;
            param = new SqlParameter("@Name", SqlDbType.VarChar, 50);
            param.Value = client.Name;
            command.Parameters.Add(param);
            param = new SqlParameter("@Surname", SqlDbType.VarChar, 50);
            param.Value = client.Surname;
            command.Parameters.Add(param);
            param = new SqlParameter("@IdNumber", SqlDbType.VarChar, 20);
            param.Value = client.IdNumber;
            command.Parameters.Add(param);

            command.Parameters.Add(new SqlParameter("@Id", client.Id));

            return command;
        }

        public static SqlCommand DeleteQuery(Client client)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM [Klient] " +
                "WHERE [Klient_ID] = @Id";

            command.Parameters.Add(new SqlParameter("@Id", client.Id));

            return command;
        }

        public static SqlCommand SelectAllQuery()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT [Klient_ID], [Imię], [Nazwisko], [Nr_dowodu] FROM [Klient]" +
                "ORDER BY [Nazwisko]";

            return command;
        }

        public static SqlCommand SelectBySurnameQuery(string surname)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT [Klient_ID], [Imię], [Nazwisko], [Nr_dowodu] FROM [Klient]" +
                "WHERE Nazwisko LIKE @Surname";
            command.Parameters.Add(new SqlParameter("@Surname", surname));

            return command;
        }

    }
}
