using System;
using System.Collections.Generic;

namespace EtiqaWebApp1.Models;

public partial class MstUser
{
    public int Id { get; set; }

    public string Uname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phonenum { get; set; }

    public string? Skillset { get; set; }

    public string? Hobby { get; set; }
    public MstUser() { }
}


