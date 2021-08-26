using System.ComponentModel.DataAnnotations;

namespace Impulso.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}