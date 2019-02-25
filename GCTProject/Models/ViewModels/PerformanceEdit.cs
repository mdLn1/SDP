using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTProject.Models.ViewModels
{
    public class PerformanceEdit : PerformanceCreation
    {
        public string Id { get; set; }
        public new byte[] Picture { get; set; }
    }
}
