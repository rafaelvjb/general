using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TagMyCoins.Domain.Entities;
using TagMyCoins.Infra.Data.Context;

namespace TagMyCoins.UI.MVC.Controllers
{
    public class EntriesController : Controller
    {
        private TagMyCoinsContext db = new TagMyCoinsContext();

        // GET: Entries
        public async Task<ActionResult> Index()
        {
            return View(await db.Entries.ToListAsync());
        }

        // GET: Entries/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entry entry = await db.Entries.FindAsync(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        // GET: Entries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EntryId,Amount,EntryDate,TypeTransaction,Notes,CreatedDate,CreatedByUser,UpdatedDate,UpdatedByUser")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                entry.EntryId = Guid.NewGuid();

                entry.CreatedByUser = Guid.NewGuid();
                entry.CreatedDate = DateTime.Now;
                entry.UpdatedByUser = Guid.NewGuid();
                entry.UpdatedDate = DateTime.Now;
                entry.EntryDate = DateTime.Now;

                db.Entries.Add(entry);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(entry);
        }

        // GET: Entries/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entry entry = await db.Entries.FindAsync(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EntryId,Amount,EntryDate,TypeTransaction,Notes,CreatedDate,CreatedByUser,UpdatedDate,UpdatedByUser")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entry).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entry);
        }

        // GET: Entries/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entry entry = await db.Entries.FindAsync(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Entry entry = await db.Entries.FindAsync(id);
            db.Entries.Remove(entry);
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
