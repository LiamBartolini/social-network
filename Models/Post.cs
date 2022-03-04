using System;
using System.Collections.Generic;

namespace fake_social.Models
{
    public partial class Post
    {
        public long Id { get; set; }
        public string Image { get; set; } = null!;
        public string? Description { get; set; }
        public string? Tags { get; set; }
    }
}
