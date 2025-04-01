namespace TestApi1.DTO.Request
{
    public class ProductCreationRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
