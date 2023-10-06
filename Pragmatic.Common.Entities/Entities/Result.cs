using System;

namespace Pragmatic.Common.Entities.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Balance { get; set; } = 0;
        public decimal Equity { get; set; } = 0;
        public decimal UsedMargin { get; set; } = 0;
        public string Symbol { get; set; }
        public decimal Ask { get; set; } = 0;
        public decimal Bid { get; set; } = 0;
        public int Step { get; set; } = 0;
        public decimal TradingLotSize { get; set; } = 0.01M;
        public decimal NextLotSize { get; set; } = 0;
        public decimal NextIncrease { get; set; } = 0;
        public decimal Longs { get; set; } = 0;
        public decimal Shorts { get; set; } = 0;
        public int OrderCount { get; set; } = 0;
        public DateTime ResultTime { get; set; } = DateTime.UtcNow;
        public virtual Account Account { get; set; }
    }
}
