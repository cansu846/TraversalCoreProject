﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppUserDto
{
    public class AppUserRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
