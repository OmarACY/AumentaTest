using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AumentaTest.Ejercicio3.Models;

namespace AumentaTest.Ejercicio3.Controllers
{
    public class UserRolesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: UserRoles
        public async Task<ActionResult> Index()
        {
            var userRole = db.UserRole.Include(u => u.Role).Include(u => u.User);
            return View(await userRole.ToListAsync());
        }

        // GET: UserRoles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = await db.UserRole.FindAsync(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // GET: UserRoles/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RoleId,UserId")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                db.UserRole.Add(userRole);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", userRole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", userRole.UserId);
            return View(userRole);
        }

        // GET: UserRoles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = await db.UserRole.FindAsync(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", userRole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", userRole.UserId);
            return View(userRole);
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RoleId,UserId")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRole).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", userRole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", userRole.UserId);
            return View(userRole);
        }

        // GET: UserRoles/Delete/5
        public async Task<ActionResult> Delete(int? userId, int? roleId)
        {
            if (userId == null || roleId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = await db.UserRole
                .Where(x => x.UserId == userId)
                .Where(x => x.RoleId == roleId)
                .Include(x => x.User)
                .Include(x => x.Role).FirstOrDefaultAsync();

            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? userId, int? roleId)
        {
            UserRole userRole = await db.UserRole
                .Where(x => x.UserId == userId)
                .Where(x => x.RoleId == roleId).FirstAsync();
            db.UserRole.Remove(userRole);
            await db.SaveChangesAsync();
            return RedirectToAction("Edit", "Users", new { id = userId });
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
