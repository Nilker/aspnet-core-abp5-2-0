using System.ComponentModel.DataAnnotations;

namespace XyAuto.It.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}

