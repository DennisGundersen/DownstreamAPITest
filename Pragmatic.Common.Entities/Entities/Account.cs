using System;
using System.Collections.Generic;

namespace Pragmatic.Common.Entities.Entities
{
    public class Account
    {
        public Account()
        {
            Alerts = new HashSet<Alert>();
            Orders = new HashSet<Order>();
            Results = new HashSet<Result>();
            Progresses = new HashSet<Progress>();
        }

        public int Id { get; set; } = 0;
        public int StrategyId { get; set; }
        public int AccountNumber { get; set; } = 0;
        public string AccountName { get; set; } = "";
        public string BrokerName { get; set; } = "";
        public string Symbol { get; set; } = "";
        public decimal StepGrowthFactor { get; set; } = 0;
        public decimal StartingBalance { get; set; } = 0;
        public int StartFactor { get; set; } = 0;
        public decimal Commission { get; set; } = 0;
        public bool IsLive { get; set; } = false;
        public string AccountCurrency { get; set; } = "";
        public DateTime RegisteredTime { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Alert> Alerts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Progress> Progresses { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual Projection Projection { get; set; }
        public virtual Status Status { get; set; }
        public virtual Variables Variables { get; set; }
    }
}
