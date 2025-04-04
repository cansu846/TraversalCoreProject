using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //Email bulteni.Subscribe bulteni
    public class Newsletter
    {
        [Key]
        public int NewsletterID { get; set; }
        public string Email { get; set; }
    }
}
