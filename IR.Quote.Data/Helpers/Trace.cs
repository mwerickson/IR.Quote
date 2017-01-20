using System;

namespace IR.Quote.Data.Helpers
{
    public static class Trace
    {
        public static Action<string, object[]> TraceImplementation { get; set; }

        public static void Message(string format, params object[] args)
        {
#if TRACE
            TraceImplementation?.Invoke(format, args);
#endif
        }
    }
}