using System.ComponentModel.DataAnnotations;

namespace XyAuto.It.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}
