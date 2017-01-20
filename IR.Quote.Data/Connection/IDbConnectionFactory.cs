using SQLite.Net;

namespace IR.Quote.Data.Connection
{
    public interface IDbConnectionFactory
    {
        SQLiteConnection OpenDbConnection(bool trace = false);
        SQLiteConnection CreateDbConnection();
    }
}