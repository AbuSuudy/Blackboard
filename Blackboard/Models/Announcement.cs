using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blackboard.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [DisplayName ("Date and Time")]
        public string DateOfAnnouncement { get; set; }
        [DisplayName("Engagement")]
        public string NumberOfStudentsSeen { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ApplicationUser User { get; set; }
        
    }
}