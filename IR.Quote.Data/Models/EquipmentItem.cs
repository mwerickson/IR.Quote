using System.Collections.Generic;

namespace IR.Quote.Data.Models
{
    public class EquipmentItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Available { get; set; }
        public string BookVal1 { get; set; }
        public string BookVal2 { get; set; }
        public string BookVal3 { get; set; }
        public string MarketVal1 { get; set; }
        public string MarketVal2 { get; set; }
        public string MarketVal3 { get; set; }
        public string FloorVal1 { get; set; }
        public string FloorVal2 { get; set; }
        public string FloorVal3 { get; set; }
    }
}