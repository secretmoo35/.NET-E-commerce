using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NETEcommerce.Models;
using System.Diagnostics;

namespace ASP.NETEcommerce.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Address
        public async Task<ActionResult> Index()
        {
            return View(await db.Addresses.ToListAsync());
        }

        // GET: Address/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressModel addressModel = await db.Addresses.FindAsync(id);
            if (addressModel == null)
            {
                return HttpNotFound();
            }
            return View(addressModel);
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Detail,District,Subdistrict,Province,Postcode")] AddressModel addressModel,string formCreate)
        {
            if (ModelState.IsValid)
            {
                switch (formCreate)
                {
                    case "Create":
                        db.Addresses.Add(addressModel);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    case "Click":
                        return Click(addressModel);
                }
            }

            return View(addressModel);
        }

        // GET: Address/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressModel addressModel = await db.Addresses.FindAsync(id);
            if (addressModel == null)
            {
                return HttpNotFound();
            }
            return View(addressModel);
        }

        // POST: Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Detail,District,Subdistrict,Province,Postcode")] AddressModel addressModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addressModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(addressModel);
        }

        // GET: Address/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressModel addressModel = await db.Addresses.FindAsync(id);
            if (addressModel == null)
            {
                return HttpNotFound();
            }
            return View(addressModel);
        }

        // POST: Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AddressModel addressModel = await db.Addresses.FindAsync(id);
            db.Addresses.Remove(addressModel);
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

        private ActionResult Click(AddressModel addressModel)
        {
            // process the cancellation request here.
            Debug.WriteLine("Clicked!!!");
            return View(addressModel);
        }
    }
}
