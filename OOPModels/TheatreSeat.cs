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
        public char ColumnLetter { get; set; }
        public bool Booked { get; set; }
    }
}
