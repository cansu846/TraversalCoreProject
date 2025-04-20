using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; } 
        public string CommentUser { get; set; } 
        public DateTime CommentDate { get; set; } 
        public string CommentContent { get; set; } 
        public bool CommentState { get; set; }
        public string CommentUserImage { get; set; }

        //Veri tabanında Comment tablosunda bir DestinationId sütunu oluşturur.
        //Comment e ait olan hangi "Destination"a ait olduğunu belirtir.
        public int DestinationId { get; set; } 

        //Navigation property olarak kullanılıyor. Kullanılmazssa da ilişki kurulur amaç verimli şekilde veri çekebilmek.
        public Destination Destination { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
