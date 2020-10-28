using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    public class TasksController : Controller
    {
        private TaskManagementContext db = new TaskManagementContext();

        // GET: Tasks
        public async Task<ActionResult> Index()
        {
            var tasks = db.Tasks.Include(t => t.Priority).Include(t => t.Project).Include(t => t.TaskStatus);
            return View(await tasks.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.PriorityID = new SelectList(db.Priorities, "PriorityID", "name");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "name");
            ViewBag.TaskStatusID = new SelectList(db.TaskStatuses, "TaskStatusID", "name");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TaskID,name,description,start_date,due_date,estimated_time,tracked_time,created_at,updated_at,ProjectID,TaskStatusID,PriorityID")] Models.Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PriorityID = new SelectList(db.Priorities, "PriorityID", "name", task.PriorityID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "name", task.ProjectID);
            ViewBag.TaskStatusID = new SelectList(db.TaskStatuses, "TaskStatusID", "name", task.TaskStatusID);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.PriorityID = new SelectList(db.Priorities, "PriorityID", "name", task.PriorityID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "name", task.ProjectID);
            ViewBag.TaskStatusID = new SelectList(db.TaskStatuses, "TaskStatusID", "name", task.TaskStatusID);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TaskID,name,description,start_date,due_date,estimated_time,tracked_time,created_at,updated_at,ProjectID,TaskStatusID,PriorityID")] Models.Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PriorityID = new SelectList(db.Priorities, "PriorityID", "name", task.PriorityID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "name", task.ProjectID);
            ViewBag.TaskStatusID = new SelectList(db.TaskStatuses, "TaskStatusID", "name", task.TaskStatusID);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Models.Task task = await db.Tasks.FindAsync(id);
            db.Tasks.Remove(task);
            await db.SaveChangesAsync();
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
    }
}
