using Microsoft.AspNetCore.Identity;

namespace MatriculaEscolarIPTC.Models;

public class AppUser : IdentityUser
{
    public string? NombreCompleto { get; set; }
}
