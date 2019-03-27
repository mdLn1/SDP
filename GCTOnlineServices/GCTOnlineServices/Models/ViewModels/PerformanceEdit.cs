using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.ViewModels
{
    public class PerformanceEdit : PlayForCreation
    {
        public int Id { get; set; }
        public new byte[] Picture { get; set; }
    }
}
