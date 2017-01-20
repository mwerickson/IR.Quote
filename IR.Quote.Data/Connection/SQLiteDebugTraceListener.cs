using System.Diagnostics;
using SQLite.Net;

namespace IR.Quote.Data.Connection
{
    public class SQLiteDebugTraceListener : ITraceListener
    {
        public void Receive(string message)
        {
            Debug.WriteLine(message);
        }
    }
}