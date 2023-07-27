namespace Pragmatic.Core.API.Models
{
    public class ValueModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ValueModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
