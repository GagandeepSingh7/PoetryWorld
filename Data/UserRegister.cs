using System;
using System.Collections.Generic;

namespace Login.Data;

public partial class UserRegister
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}
