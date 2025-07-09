using System.ComponentModel.DataAnnotations;

namespace JobApplicationPortal.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}