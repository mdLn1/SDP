using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.OOPModels
{
    public class TheatreSeat
    {
        public int Id { get; set; }
        public string Band { get; set; }
        public int RowNumber { get; set; }
        public string ColumnLetter { get; set; }
        public byte Booked { get; set; }
        public decimal Price { get; set; }
        public decimal ReducedPrice { get; set; }
    }
}
