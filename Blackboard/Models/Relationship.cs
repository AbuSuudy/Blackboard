using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blackboard.Models
{
    public class Relationship
    {
        public int RelationshipId { get; set; }
        public ICollection<Announcement> Announements { get; set; }
        public virtual Comment CommentRelationship{ get; set; }
        public virtual Announcement AnnouncementRelationship { get; set; }


    }
}