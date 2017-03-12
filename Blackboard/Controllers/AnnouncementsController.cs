using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blackboard.Models;
using Microsoft.AspNet.Identity;

namespace Blackboard.Controllers
{
    [RequireHttps]
    public class AnnouncementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Announcements
        public ActionResult Index()
        {
            AddAllAnouncements();
            return View();
        }

        public void AddAllAnouncements()
        {
            ICollection<Announcement> announceList = db.Announcements.ToList();
            Relationship relationship = new Relationship();
            relationship.Announements = new List<Announcement>();

            foreach(var item in announceList)
            {
                relationship.Announements.Add(item);
            }

            db.Relationships = relationship;
            db.SaveChanges();
        }

        private IEnumerable<Announcement> GetMyAnnouncements()
        {
            String CurrentUserID = User.Identity.GetUserId();
            ApplicationUser CurrentUser = db.Users.FirstOrDefault(
            x => x.Id == CurrentUserID);
            return  db.Announcements.ToList().Where(x => x.User == CurrentUser);
        }

        public ActionResult BuildAnnouncementTable()
        {
            AddAllAnouncements();
            return PartialView("_AnnouncementTable", db.Relationships);
        }

        // GET: Announcements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // GET: Announcements/Create
        [Authorize(Roles = "Lecturer")]
        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Lecturer")]
        public ActionResult Create([Bind(Include = "Id,Title,Description,DateOfAnnouncement")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                string currentUserID = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(
                    x => x.Id == currentUserID);
                announcement.User = currentUser;
                announcement.Comments = new List<Comment>();
                announcement.DateOfAnnouncement = DateTime.UtcNow.ToString();
                db.Announcements.Add(announcement);
                AddAllAnouncements();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(announcement);
        }

        // GET: Announcements/Edit/5
        [Authorize(Roles = "Lecturer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Lecturer")]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,DateOfAnnouncement,NumberOfStudentsSeen")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(announcement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        public ActionResult EditComment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComment([Bind(Include = "commentId,commentString,announceId")] Comment comment)
        {
            if (ModelState.IsValid)
            {

                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Announcements/Delete/5


        // POST: Announcements/Delete/5
       

        // GET: Announcements/Delete/5
        public ActionResult EditDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("EditDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult EditDeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(Relationship comment, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                announcement.Comments.Add(comment.CommentRelationship);
                db.Comments.Add(comment.CommentRelationship);
                db.SaveChanges();
                ModelState.Clear();
                return BuildAnnouncementTable();
            }


            return View(announcement);
        }

        // GET: Announcements/Delete/5
        [Authorize(Roles = "Lecturer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxDeleteAnnouncement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }

            LinkedList<Comment> cList = new LinkedList<Comment>(); 

            
            foreach (var comments in announcement.Comments)
            {
                cList.AddFirst(comments);
            }

            
            foreach (var comments in cList)
            {
                db.Comments.Remove(comments);
            }
            db.Announcements.Remove(announcement); 
            db.SaveChanges();

            return BuildAnnouncementTable();
        }
    }
}
