namespace API.DTOs.Response
{
    public class ItemsCategoriesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Place { get; set; }
        public string? Remark { get; set; } = null;
    }
}
