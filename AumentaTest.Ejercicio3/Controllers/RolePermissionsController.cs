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
    public class RolePermissionsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: RolePermissions
        public async Task<ActionResult> Index()
        {
            var rolePermission = db.RolePermission.Include(r => r.Permission).Include(r => r.Role);
            return View(await rolePermission.ToListAsync());
        }

        // GET: RolePermissions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePermission rolePermission = await db.RolePermission.FindAsync(id);
            if (rolePermission == null)
            {
                return HttpNotFound();
            }
            return View(rolePermission);
        }

        // GET: RolePermissions/Create
        public ActionResult Create()
        {
            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Name");
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name");
            return View();
        }

        // POST: RolePermissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PermissionId,RoleId")] RolePermission rolePermission)
        {
            if (ModelState.IsValid)
            {
                db.RolePermission.Add(rolePermission);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Name", rolePermission.PermissionId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", rolePermission.RoleId);
            return View(rolePermission);
        }

        // GET: RolePermissions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePermission rolePermission = await db.RolePermission.FindAsync(id);
            if (rolePermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Name", rolePermission.PermissionId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", rolePermission.RoleId);
            return View(rolePermission);
        }

        // POST: RolePermissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PermissionId,RoleId")] RolePermission rolePermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolePermission).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Name", rolePermission.PermissionId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", rolePermission.RoleId);
            return View(rolePermission);
        }

        // GET: RolePermissions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePermission rolePermission = await db.RolePermission.FindAsync(id);
            if (rolePermission == null)
            {
                return HttpNotFound();
            }
            return View(rolePermission);
        }

        // POST: RolePermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RolePermission rolePermission = await db.RolePermission.FindAsync(id);
            db.RolePermission.Remove(rolePermission);
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
