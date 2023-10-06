namespace Pragmatic.Common.Entities.Entities
{
    public class Progress
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Lots { get; set; } = 0.01M;
        public int Steps { get; set; } = 0;
        public virtual Account Account { get; set; }
    }
}
