using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pragmatic.Common.Entities.Entities
{
    public class Alert
    {
        public int Id { get; set; }
        public decimal Rate { get; set; } = 9.9999M;
        public bool TriggerAbove { get; set; } = false;

        [Column("IsActive")]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;
        public string UserTag { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
