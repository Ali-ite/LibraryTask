using System.ComponentModel.DataAnnotations;

namespace LibraryTask.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}