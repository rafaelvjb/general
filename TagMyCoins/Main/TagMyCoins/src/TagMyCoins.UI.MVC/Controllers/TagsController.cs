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
using TagMyCoins.Application.ViewModels;

namespace TagMyCoins.UI.MVC.Controllers
{
    public class TagsController : Controller
    {
        private TagMyCoinsContext db = new TagMyCoinsContext();

        // GET: Tags
        public async Task<ActionResult> Index()
        {
            return View(await db.Tags.ToListAsync());
        }

        // GET: Tags/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = await db.Tags.FindAsync(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // GET: Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TagId,Name,ParentTagId")] TagViewModel tagViewModel)
        {
        //    if (ModelState.IsValid)
        //    {
        //        tagViewModel.TagId = Guid.NewGuid();

        //        tagViewModel.CreatedByUser = Guid.NewGuid();
        //        tagViewModel.CreatedDate = DateTime.Now;
        //        tagViewModel.UpdatedByUser = Guid.NewGuid();
        //        tagViewModel.UpdatedDate = DateTime.Now;

        //        var entry = db.Entries.FirstOrDefault(e => e.EntryId == Guid.Parse("59e1fa89-95a0-4077-aa00-1b7b80f895dd"));
        //        tagViewModel.Entries.Add(entry);
        //        //    new Entry{
        //        //    EntryId = Guid.Parse("59e1fa89-95a0-4077-aa00-1b7b80f895dd"),
                    
        //        //});


        //        db.Tags.Add(tagViewModel);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

            return View(tagViewModel);
        }

        // GET: Tags/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = await db.Tags.FindAsync(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TagId,Name,ParentTagId,CreatedDate,CreatedByUser,UpdatedDate,UpdatedByUser")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tag).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: Tags/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = await db.Tags.FindAsync(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Tag tag = await db.Tags.FindAsync(id);
            db.Tags.Remove(tag);
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
