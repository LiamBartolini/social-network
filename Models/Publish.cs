using System;
using System.Collections.Generic;

namespace fake_social.Models
{
    public partial class Publish
    {
        public long FkIduser { get; set; }
        public long FkIdpost { get; set; }

        public virtual Post FkIdpostNavigation { get; set; } = null!;
        public virtual User FkIduserNavigation { get; set; } = null!;
    }
}
