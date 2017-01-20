using SQLiteNetExtensions.Attributes;

namespace IR.Quote.Data.Models
{
    public class LineItem : BaseModel
    {
        public string Description { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }
        [ForeignKey(typeof(Quote))]
        public long QuoteId { get; set; }
    }
}