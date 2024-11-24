using System.ComponentModel.DataAnnotations;

public class Register
{
    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Your passwords do not match")]
    public string PasswordConfirm { get; set; } = string.Empty;

    [Required]
    public string Nickname { get; set; } = string.Empty;
}
