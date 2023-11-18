using System;
using Microsoft.AspNetCore.Identity;

namespace Coraza_LabActivity1.Data
{
    public class User : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set;}
    }
}
