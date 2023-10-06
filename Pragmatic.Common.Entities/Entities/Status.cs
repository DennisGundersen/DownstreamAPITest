using System;

namespace Pragmatic.Common.Entities.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public decimal Ask { get; set; } = 0;
        public decimal Bid { get; set; } = 0;
        public decimal Balance { get; set; } = 0;
        public decimal Equity { get; set; } = 0;
        public decimal UsedMargin { get; set; } = 0;
        public decimal Longs { get; set; } = 0;
        public decimal Shorts { get; set; } = 0;
        public decimal NextLotSize { get; set; } = 0;
        public decimal NextLotIncrease { get; set; } = 0;
        public int OrderCount { get; set; } = 0;
        public int TradeCountDown { get; set; } = 0;
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public virtual Account Account { get; set; }

        // These variables are added to simplify reporting
        public int CurrentStep { get; set; } = 0;
        public int CurrentTakeProfit { get; set; } = 0;
        public decimal CurrentPipValue { get; set; } = 10;
        public decimal CurrentLotSize { get; set; } = 0.01M;
    }
}
