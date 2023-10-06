using System;

namespace Pragmatic.Common.Entities.Entities
{
    public partial class Variables
    {
        public int Id { get; set; }
        public decimal TradingLotSize { get; set; } = 0;
        public decimal ExtremeTopRate { get; set; } = 0;
        public decimal NormalTopRate { get; set; } = 0;
        public decimal CenterRate { get; set; } = 0;
        public decimal NormalBottomRate { get; set; } = 0;
        public decimal ExtremeBottomRate { get; set; } = 0;
        public decimal TestUpToRate { get; set; } = 0;
        public decimal TestDownToRate { get; set; } = 0;
        public int TestPipsUp { get; set; } = 300;
        public int TestPipsDown { get; set; } = 300;
        public int LongStabilizerSizeFactor { get; set; } = 0;
        public int ShortStabilizerSizeFactor { get; set; } = 0;
        public int LongBalancerSizeFactor { get; set; } = 0;
        public int ShortBalancerSizeFactor { get; set; } = 0;
        public int PrimerSizeFactor { get; set; } = 3;
        public int BalancerStopLossPips { get; set; } = 200;
        public int SecurePips { get; set; } = 0;
        public bool AutoLotIncrease { get; set; } = false;
        public int AutoLotSafeEQLevel { get; set; } = 100;
        public int TakeProfit { get; set; } = 49;
        public bool TradeMidTerm { get; set; } = false;
        public int FixedSpread { get; set; } = 1;
        public int ExtraLongBuffer { get; set; } = 1;
        public int ExtraShortBuffer { get; set; } = 1;
        public int WarningLevel { get; set; } = 0;
        public int HeartbeatMonitorTimer { get; set; } = 0;
        public int DatabaseLogTimer { get; set; } = 0;
        public bool AutoCloseExtremes { get; set; } = false;
        public bool RunBalancers { get; set; } = false;
        public bool RunStabilizers { get; set; } = true;
        public bool RunBreakouts { get; set; } = true;
        public bool RunWhiplash { get; set; } = false;
        public bool RunPrimers { get; set; } = false;
        public int GMTOffset { get; set; } = 0;
        public int ScreenshotTimer { get; set; } = 5;
        public decimal MaxWeight { get; set; } = 20;
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public virtual Account Account { get; set; }
    }
}
