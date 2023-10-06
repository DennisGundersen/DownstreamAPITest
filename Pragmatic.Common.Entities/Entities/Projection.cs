using System;

namespace Pragmatic.Common.Entities.Entities
{
    public class Projection
    {
        public int Id { get; set; }
        public decimal TopRate { get; set; } = 0;
        public decimal TopEquity { get; set; } = 0;
        public decimal TopBalance { get; set; } = 0;
        public decimal TopLongs { get; set; } = 0;
        public decimal TopShorts { get; set; } = 0;
        public decimal BottomRate { get; set; } = 0;
        public decimal BottomEquity { get; set; } = 0;
        public decimal BottomBalance { get; set; } = 0;
        public decimal BottomLongs { get; set; } = 0;
        public decimal BottomShorts { get; set; } = 0;
        public decimal UpRate { get; set; } = 0;
        public decimal UpEquity { get; set; } = 0;
        public decimal UpBalance { get; set; } = 0;
        public decimal UpLongs { get; set; } = 0;
        public decimal UpShorts { get; set; } = 0;
        public decimal DownRate { get; set; } = 0;
        public decimal DownEquity { get; set; } = 0;
        public decimal DownBalance { get; set; } = 0;
        public decimal DownLongs { get; set; } = 0;
        public decimal DownShorts { get; set; } = 0;
        public decimal CenterRate { get; set; } = 0;
        public decimal CenterEquity { get; set; } = 0;
        public decimal CenterBalance { get; set; } = 0;
        public decimal CenterLongs { get; set; } = 0;
        public decimal CenterShorts { get; set; } = 0;
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public virtual Account Account { get; set; }
    }
}
