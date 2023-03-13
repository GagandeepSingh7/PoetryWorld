using System.ComponentModel.DataAnnotations;

namespace Login.Models;

public class Employee
{
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //[Key]
    //public int id { get; set; }
    [Key] public string Username { get; set; }

    public string Password { get; set; }

    [Compare("Password")] public string ConfirmPassword { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
}