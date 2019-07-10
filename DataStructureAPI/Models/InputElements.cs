using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructureAPI.Models
{
    public class InputElements
    {
        public string Algorithm { get; set; }
        public int[] Items { get; set; } 
    }
    public class OutSorted {
        public string Time { get; set; }
        public string Complexity { get; set; }
        public int[] Items { get; set; }
        public string Algorithm { get; set; }
    }
}
