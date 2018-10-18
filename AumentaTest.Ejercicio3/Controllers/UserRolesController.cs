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

        // GET: UserRoles/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.Id = id;
            ViewBag.UserId = new SelectList(db.Users.Where(x => x.Id == id), "Id", "UserName");
            var userRoles = db.UserRole.Where(x => x.UserId == id).Select(r => r.RoleId).ToList();
            ViewBag.RoleId = new SelectList(db.Roles.Where(x => x.Enabled).Where(r => !userRoles.Contains(r.Id)), "Id", "Name");
            return View();
        }

        // POST: UserRoles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RoleId,UserId")] UserRole userRole)
        {

            if (ModelState.IsValid && userRole.RoleId != 0)
            {
                db.UserRole.Add(userRole);
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", "Users", new { id = userRole.UserId });
            }
            ViewBag.Id = userRole.UserId;
            ViewBag.UserId = new SelectList(db.Users.Where(x => x.Id == userRole.UserId), "Id", "UserName");
            var userRoles = db.UserRole.Where(x => x.UserId == userRole.UserId).Select(r => r.RoleId).ToList();
            ViewBag.RoleId = new SelectList(db.Roles.Where(x => x.Enabled).Where(r => !userRoles.Contains(r.Id)), "Id", "Name", userRole.RoleId);
            return View(userRole);
        }

        // GET: UserRoles/Delete/5
        public async Task<ActionResult> Delete(int? userId, int? roleId)
        {
            if (userId == null || roleId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userRole = await db.UserRole
                .Where(x => x.UserId == userId)
                .Where(x => x.RoleId == roleId)
                .Include(x => x.User)
                .Include(x => x.Role)
                .FirstOrDefaultAsync();

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
            var userRole = await db.UserRole
                .Where(x => x.UserId == userId)
                .Where(x => x.RoleId == roleId)
                .FirstAsync();

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
