using System;
using SQLite.Net.Attributes;

namespace IR.Quote.Data.Models
{
    public class BaseModel
    {
        [AutoIncrement, PrimaryKey]
        public long Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool Active { get; set; }
    }
}