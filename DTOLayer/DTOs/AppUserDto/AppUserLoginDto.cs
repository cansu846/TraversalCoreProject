﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppUserDto
{
    public class AppUserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
