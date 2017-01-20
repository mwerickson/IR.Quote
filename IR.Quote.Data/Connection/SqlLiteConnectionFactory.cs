using SQLite.Net;
using SQLite.Net.Interop;

namespace IR.Quote.Data.Connection
{
    public class SqlLiteConnectionFactory : IDbConnectionFactory
    {
        public SqlLiteConnectionFactory()
        {

        }

        public SqlLiteConnectionFactory(ISQLitePlatform platform, string filename)
        {
            Filename = filename;
            Platform = platform;
        }

        protected string Filename { get; private set; }
        protected ISQLitePlatform Platform { get; private set; }

        public virtual SQLiteConnection CreateDbConnection()
        {
            return new SQLite.Net.SQLiteConnection(Platform, Filename, false);
        }

        public virtual SQLiteConnection OpenDbConnection(bool trace = false)
        {
            return trace
                ? new SQLite.Net.SQLiteConnection(Platform, Filename, false)
                {
                    TraceListener = new SQLiteDebugTraceListener()
                }
                : new SQLite.Net.SQLiteConnection(Platform, Filename, false);
        }
    }
}