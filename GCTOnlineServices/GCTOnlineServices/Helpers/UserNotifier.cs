using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Helpers
{
   [Serializable]
    public class UserNotifier
    {
        [TempData]
        public string CssFormat { get; set; }
        [TempData]
        public string Content { get; set; }
        [TempData]
        public string MessageType { get; set; }
    }
}
