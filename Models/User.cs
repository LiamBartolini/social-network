using System;
using System.Collections.Generic;

namespace fake_social.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string? PhoneNumber { get; set; }
    }
}
