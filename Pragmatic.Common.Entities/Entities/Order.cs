using System;

namespace Pragmatic.Common.Entities.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Ticket { get; set; }
        public int OrderType { get; set; }
        public decimal Lots { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public string Symbol { get; set; }
        public decimal OpenRate { get; set; }
        public decimal CloseRate { get; set; }
        public decimal PlannedOpenRate { get; set; }
        public int OrderFunction { get; set; }
        public decimal StopLossRate { get; set; }
        public decimal TakeProfitRate { get; set; }
        public decimal Swap { get; set; }
        public decimal Commission { get; set; }
        public decimal Profit { get; set; }
        public string Comment { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
