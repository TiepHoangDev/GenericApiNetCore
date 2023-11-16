namespace GenericApiNetCore.Samples.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; } = DateTime.Now.ToString();
    }
}