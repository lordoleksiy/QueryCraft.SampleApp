namespace QueryCraft.SampleApp.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsActive { get; set; }
        public int StockQuantity { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
