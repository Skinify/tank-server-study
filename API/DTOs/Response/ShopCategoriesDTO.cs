namespace API.DTOs.Response
{
    public class ShopCategoriesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
