﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Description { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string MapLocation { get; set; }
        public bool Status { get; set; }

    }
}
