using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProject.Areas.Admin.Models
{
    public class AnnouncemenListViewModel
    {
        [Key]
        public int AnnouncementID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
