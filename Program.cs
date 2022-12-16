using InterBaseSql.Data.InterBaseClient;

namespace InterbaseDialectDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString = new IBConnectionStringBuilder
            {
                DataSource = "localhost",
                Database = "C:\\YOUR_DATABASE_PATH.IB",
                Dialect = 1, // This doesn't seem to be respected?
                UserID = "sysdba",
                Password = "masterkey",
            };

            // changing DATE to TIMESTAMP works
            const string cmdText = "CREATE PROCEDURE TEST_PROCEDURE (TEST_ARG DATE) AS BEGIN EXIT; END";
            using var connection = new IBConnection(connectionString.ToString());
            using var command = new IBCommand(cmdText, connection);
            connection.Open();
            command.ExecuteNonQuery();

            Console.WriteLine("Successfully created procedure!");
            Console.ReadLine();
        }
    }
}