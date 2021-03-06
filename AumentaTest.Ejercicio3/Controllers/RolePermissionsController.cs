﻿using System;
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

        // GET: RolePermissions/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.Id = id;
            ViewBag.RoleId = new SelectList(db.Roles.Where(x => x.Id == id), "Id", "Name");
            var rolePermissions = db.RolePermission.Where(x => x.RoleId == id).Select(r => r.PermissionId).ToList();
            ViewBag.PermissionId = new SelectList(db.Permissions.Where(x => x.Enabled).Where(r => !rolePermissions.Contains(r.Id)), "Id", "Name");

            return View();
        }

        // POST: RolePermissions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PermissionId,RoleId")] RolePermission rolePermission)
        {
            if (ModelState.IsValid && rolePermission.PermissionId != 0)
            {
                db.RolePermission.Add(rolePermission);
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", "Roles", new { id = rolePermission.RoleId });
            }
            ViewBag.Id = rolePermission.RoleId;
            ViewBag.RoleId = new SelectList(db.Roles.Where(x => x.Id == rolePermission.RoleId), "Id", "Name");
            var rolePermissions = db.RolePermission.Where(x => x.RoleId == rolePermission.RoleId).Select(r => r.PermissionId).ToList();
            ViewBag.PermissionId = new SelectList(db.Permissions.Where(x => x.Enabled).Where(r => !rolePermissions.Contains(r.Id)), "Id", "Name",rolePermission.PermissionId);

            return View(rolePermission);
        }

        // GET: RolePermissions/Delete/5
        public async Task<ActionResult> Delete(int? roleId, int? permissionId)
        {
            if (roleId == null || permissionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var rolePermission = await db.RolePermission.
                Where(x => x.RoleId == roleId)
                .Where(x => x.PermissionId == permissionId)
                .Include(x => x.Role)
                .Include( x => x.Permission)
                .FirstOrDefaultAsync();

            if (rolePermission == null)
            {
                return HttpNotFound();
            }
            return View(rolePermission);
        }

        // POST: RolePermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int roleId, int permissionId)
        {
            var rolePermission = await db.RolePermission
                .Where( x => x.RoleId == roleId)
                .Where( x => x.PermissionId == permissionId)
                .FirstAsync();

            db.RolePermission.Remove(rolePermission);
            await db.SaveChangesAsync();

            return RedirectToAction("Edit", "Roles", new { id = roleId });
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
