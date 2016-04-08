namespace MvvmExample.Models
{
    public class Product
    {
        public string Id { get; private set; }

        public string Description { get; private set; }

        public Product(string id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}