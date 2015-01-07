using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseWebTamplate.Models
{
    public class Vijest
    {
        public int VijestId { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public string Autor { get; set; }
        public DateTime Timestamp { get; set; }
        
    
    }
}