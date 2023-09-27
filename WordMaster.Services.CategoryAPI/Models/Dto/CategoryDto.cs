using System.ComponentModel.DataAnnotations;

namespace WordMaster.Services.CategoryAPI.Models.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public string? UserId { get; set; }
    }
}
