using System;
using System.Collections.Generic;

namespace BeeMVC.Models
{
    public partial class BeeData
    {
        public int ID { get; set; }
        public string BeeName { get; set; }
        public decimal Health { get; set; }
        public string Dead { get; set; }
    }
}
