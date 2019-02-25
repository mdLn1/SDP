using System;
using System.Collections.Generic;

namespace GCTProject.Data
{
    public partial class Review
    {
        public int Id { get; set; }
        public string PerformanceId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public byte[] Date { get; set; }

        public virtual Performance Performance { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
