using System;
using System.Collections.Generic;

namespace Online_Courses.Models;

public partial class Register
{
    public int Id { get; set; }

    public string? Profileimg { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? City { get; set; }

    public string? Qualification { get; set; }
}
