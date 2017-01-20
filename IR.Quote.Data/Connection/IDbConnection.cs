using SQLite.Net;

namespace IR.Quote.Data.Connection
{
    public interface IDbConnection
    {
        string Filename { get; }
        SQLiteConnection Connection { get; }
    }
}