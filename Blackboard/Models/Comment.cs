using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blackboard.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [DisplayName("Comments")]
        [StringLength(500)]
        [Required]
        public string CommentString { get; set; }
        public int AnnnounceID { get; set; }
    }
}