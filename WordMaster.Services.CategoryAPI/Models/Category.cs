using System.ComponentModel.DataAnnotations;

namespace WordMaster.Services.CategoryAPI.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public string? UserId { get; set; }
    }
}
