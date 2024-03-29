﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.OOPModels
{
    public class TheatrePlay
    {
        public int Id { get; set; }
        public decimal PriceStart { get; set; }
        public decimal PriceEnd { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AgeRestriction { get; set; }
        public byte[] Picture { get; set; }
        public List<Performance> Performances { get; set; }
        public List<Models.Review> Reviews { get; set; }
    }
}
