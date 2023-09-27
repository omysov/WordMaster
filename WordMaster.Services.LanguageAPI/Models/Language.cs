using System.ComponentModel.DataAnnotations;

namespace WordMaster.Services.LanguageAPI.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
