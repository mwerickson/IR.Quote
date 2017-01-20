using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace IR.Quote.Data.Models
{
    public class Quote : BaseModel
    {
        public string QuoteNumber { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.None)]
        public List<LineItem> LineItems { get; set; }
    }
}