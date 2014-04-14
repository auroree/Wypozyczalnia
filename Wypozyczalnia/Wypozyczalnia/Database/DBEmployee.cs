using System.Data;
using System.Data.SqlClient;
using Wypozyczalnia.Model;

namespace Wypozyczalnia.Database
{
    public class DBEmployee
    {
        public DBEmployee()
        {

        }

        public static SqlCommand InsertQuery(Employee employee)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "INSERT INTO [dbo].[Pracownik] ([Imię], [Nazwisko], [Data_urodzenia], " +
                "[Miejsce_urodzenia], [Pensja], [Funkcja_Funkcja_ID]) " +
                "VALUES (@Name, @Surname, @Date, @Place, @Salary, " +
                "(SELECT [Funkcja_ID] FROM [dbo].[Funkcja] " +
                "WHERE [Nazwa_funkcji] LIKE @Function))";

            // wersja z obcinaniem dlugosci parametru
            SqlParameter param;
            param = new SqlParameter("@Name", SqlDbType.VarChar, 50);
            param.Value = employee.Name;
            command.Parameters.Add(param);
            param = new SqlParameter("@Surname", SqlDbType.VarChar, 50);
            param.Value = employee.Surname;
            command.Parameters.Add(param);
            param = new SqlParameter("@Date", SqlDbType.Date);
            param.Value = employee.DateOfBirth.Date;
            command.Parameters.Add(param);
            param = new SqlParameter("@Place", SqlDbType.VarChar, 100);
            param.Value = employee.PlaceOfBirth;
            command.Parameters.Add(param);
            param = new SqlParameter("@Salary", SqlDbType.Float);
            param.Value = employee.Salary;
            command.Parameters.Add(param);
            param = new SqlParameter("@Function", SqlDbType.VarChar, 50);
            param.Value = employee.Function;
            command.Parameters.Add(param);

            return command;
        }

        public static SqlCommand UpdateQuery(Employee employee)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE [Pracownik] SET [Imię] = @Name, [Nazwisko] = @Surname, [Data_urodzenia] = @Date, " +
                "[Miejsce_urodzenia] = @Place, [Pensja] = @Salary, [Funkcja_Funkcja_ID] = " +
                "(SELECT [Funkcja_ID] FROM [dbo].[Funkcja] " +
                "WHERE [Nazwa_funkcji] = @Function)" +
                "WHERE [Pracownik_ID] = @Id";

            // wersja z obcinaniem dlugosci parametru
            SqlParameter param;
            param = new SqlParameter("@Name", SqlDbType.VarChar, 50);
            param.Value = employee.Name;
            command.Parameters.Add(param);
            param = new SqlParameter("@Surname", SqlDbType.VarChar, 50);
            param.Value = employee.Surname;
            command.Parameters.Add(param);
            param = new SqlParameter("@Date", SqlDbType.Date);
            param.Value = employee.DateOfBirth.Date;
            command.Parameters.Add(param);
            param = new SqlParameter("@Place", SqlDbType.VarChar, 100);
            param.Value = employee.PlaceOfBirth;
            command.Parameters.Add(param);
            param = new SqlParameter("@Salary", SqlDbType.Float);
            param.Value = employee.Salary;
            command.Parameters.Add(param);
            param = new SqlParameter("@Function", SqlDbType.VarChar);
            param.Value = employee.Function;
            command.Parameters.Add(param);

            command.Parameters.Add(new SqlParameter("@Id", employee.Id));

            return command;
        }

        public static SqlCommand DeleteQuery(Employee employee)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM [Pracownik] " +
                "WHERE [Pracownik_ID] = @Id";

            command.Parameters.Add(new SqlParameter("@Id", employee.Id));

            return command;
        }

        public static SqlCommand SelectAllQuery()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT [Pracownik_ID], [Imię], [Nazwisko], [Data_urodzenia], [Miejsce_urodzenia], [Pensja], " +
                "(SELECT [Nazwa_funkcji] FROM [dbo].[Funkcja] " +
                "WHERE [Funkcja_ID] = [Funkcja_Funkcja_ID]) as Funkcja " +
                "FROM [Pracownik]" +
                "ORDER BY [Nazwisko]";

            return command;
        }

        public static SqlCommand SelectBySurnameQuery(string surname)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT [Pracownik_ID], [Imię], [Nazwisko], [Data_urodzenia], [Miejsce_urodzenia], [Pensja], " +
                "(SELECT [Nazwa_funkcji] FROM [dbo].[Funkcja] " +
                "WHERE [Funkcja_ID] = [Funkcja_Funkcja_ID]) as Funkcja " +
                "FROM [Pracownik]" +
                "WHERE Nazwisko LIKE @Surname " +
                "ORDER BY [Nazwisko]";
            command.Parameters.Add(new SqlParameter("@Surname", surname));

            return command;
        }

        public static SqlCommand SelectFunctions()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT [Nazwa_funkcji] FROM [Funkcja] " +
                "ORDER BY [Nazwa_funkcji]";

            return command;
        }

        public static SqlCommand SelectByFunctionQuery(string function)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT [Pracownik_ID], [Imię], [Nazwisko], [Data_urodzenia], [Miejsce_urodzenia], " +
                "[Pensja], [Nazwa_funkcji] as Funkcja " +
                "FROM [Pracownik] " +
                "INNER JOIN [Funkcja] ON [Pracownik].[Funkcja_Funkcja_ID] = [Funkcja].[Funkcja_ID] " +
                "WHERE [Nazwa_funkcji] LIKE @Function " +
                "ORDER BY [Nazwisko] ";
            command.Parameters.Add(new SqlParameter("@Function", function));

            return command;
        }

    }
}
