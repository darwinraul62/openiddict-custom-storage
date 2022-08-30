using System.ComponentModel.DataAnnotations;

namespace AuthServer.ViewModels;

public class LoginViewModel
{
    [Required]
    public string? LogonName { get; set; }
    [Required]
    public string? Password { get; set; }
    public string? ReturnUrl { get; set; }
}