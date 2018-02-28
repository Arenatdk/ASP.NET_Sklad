using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sklad.Models;

namespace Sklad.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private SkladContext db = new SkladContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Client).Include(o => o.Employee);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);

            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "Id", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            ViewBag.Products = db.Products.ToList();
            return View();
        }

        // POST: Orders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientID,EmployeeId,DateAdd,Adress")] Order order, int[] SelectedProducts)
        {
            if (ModelState.IsValid)
            {
                Order newOrder = new Order();
                newOrder.ClientID = order.ClientID;
                newOrder.EmployeeId = order.EmployeeId;
                newOrder.DateAdd = order.DateAdd;
                newOrder.Adress = order.Adress;

                newOrder.Product.Clear();
                if (SelectedProducts != null)
                {
                    foreach (var item in db.Products.Where(m => SelectedProducts.Contains(m.Id)))
                    {
                        Debug.WriteLine(item.Mark);
                        newOrder.Product.Add(item);
                    }
                }
                db.Orders.Add(newOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "Id", "Name", order.ClientID);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", order.EmployeeId);

            ViewBag.Products = db.Products.ToList();
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "Id", "Name", order.ClientID);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", order.EmployeeId);

            ViewBag.Products = db.Products.ToList();
            return View(order);
        }

        // POST: Orders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientID,EmployeeId,DateAdd,Adress")] Order order,int[] SelectedProducts)
        {
            if (ModelState.IsValid)
            {
                Order newOrder = db.Orders.Find(order.Id);
                newOrder.ClientID = order.ClientID;
                newOrder.EmployeeId = order.EmployeeId;
                newOrder.DateAdd = order.DateAdd;
                newOrder.Adress = order.Adress;

                newOrder.Product.Clear();
                if (SelectedProducts != null)
                {
                    foreach (var item in db.Products.Where(m => SelectedProducts.Contains(m.Id)))
                    {
                        Debug.WriteLine(item.Mark);
                        newOrder.Product.Add(item);
                    }
                }
                db.Entry(newOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "Id", "Name", order.ClientID);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", order.EmployeeId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
