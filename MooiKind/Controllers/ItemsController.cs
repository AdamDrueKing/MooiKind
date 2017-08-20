using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MooiKind;

namespace MooiKind.Controllers
{
    public class ItemsController : Controller
    {
        private MooiKindEntities db = new MooiKindEntities();

        // GET: Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Color1).Include(i => i.Description1).Include(i => i.Name1).Include(i => i.Price1).Include(i => i.Size1);
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Color1");
            ViewBag.DescriptionID = new SelectList(db.Descriptions, "DescriptionID", "Description1");
            ViewBag.NameID = new SelectList(db.Names, "NameID", "Name1");
            ViewBag.PriceID = new SelectList(db.Prices, "PriceID", "PriceID");
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "Size1");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,Name,Price,Color,Size,Description,NameID,PriceID,ColorID,SizeID,DescriptionID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Color1", item.ColorID);
            ViewBag.DescriptionID = new SelectList(db.Descriptions, "DescriptionID", "Description1", item.DescriptionID);
            ViewBag.NameID = new SelectList(db.Names, "NameID", "Name1", item.NameID);
            ViewBag.PriceID = new SelectList(db.Prices, "PriceID", "PriceID", item.PriceID);
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "Size1", item.SizeID);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Color1", item.ColorID);
            ViewBag.DescriptionID = new SelectList(db.Descriptions, "DescriptionID", "Description1", item.DescriptionID);
            ViewBag.NameID = new SelectList(db.Names, "NameID", "Name1", item.NameID);
            ViewBag.PriceID = new SelectList(db.Prices, "PriceID", "PriceID", item.PriceID);
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "Size1", item.SizeID);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,Name,Price,Color,Size,Description,NameID,PriceID,ColorID,SizeID,DescriptionID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Color1", item.ColorID);
            ViewBag.DescriptionID = new SelectList(db.Descriptions, "DescriptionID", "Description1", item.DescriptionID);
            ViewBag.NameID = new SelectList(db.Names, "NameID", "Name1", item.NameID);
            ViewBag.PriceID = new SelectList(db.Prices, "PriceID", "PriceID", item.PriceID);
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "Size1", item.SizeID);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
    }
}
