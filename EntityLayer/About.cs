﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class About
    {
        public int AboutID{ get; set; }
        public string Title { get; set; }
        public string Image1 { get; set; }
        public string Description1 { get; set; }
        public string Image2 { get; set; }
        public string Description2 { get; set; }
        public bool Status { get; set; }
    }
}
