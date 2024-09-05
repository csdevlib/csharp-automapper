namespace BeyondNet.AutoMapper.Library.Entities
{
    public class Product
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public DateTime RegisterDate { get; set; }

        public Product(string id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
            RegisterDate = DateTime.Now;
        }
    }
}
