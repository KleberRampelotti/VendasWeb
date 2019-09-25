using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace VendasWeb
{
    public class PedidoProdutosController : Controller
    {
        private VendasWebContext db = new VendasWebContext();

        // GET: PedidoProdutos
        public ActionResult Index(int? id)
        {
            var pedidoProduto = db.PedidoProduto.Include(p => p.Pedido).Include(p => p.Produto).Where(p => p.Pedido.Id == id);
            return View(pedidoProduto.ToList());
        }

        // GET: PedidoProdutos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoProduto pedidoProduto = db.PedidoProduto.Find(id);
            if (pedidoProduto == null)
            {
                return HttpNotFound();
            }
            return View(pedidoProduto);
        }

        // GET: PedidoProdutos/Create
        public ActionResult Create()
        {
            ViewBag.PedidoID = new SelectList(db.Pedido, "Id", "Id");
            ViewBag.ProdutoID = new SelectList(db.Produto, "Id", "Nome");            
            return View();
        }

        // POST: PedidoProdutos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PedidoID,ProdutoID,Valor,Quantidade")] PedidoProduto pedidoProduto)
        {
            if (ModelState.IsValid)
            {
                db.PedidoProduto.Add(pedidoProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PedidoID = new SelectList(db.Pedido, "Id", "Id", pedidoProduto.PedidoID);
            ViewBag.ProdutoID = new SelectList(db.Produto, "Id", "Nome", pedidoProduto.ProdutoID);
            return View(pedidoProduto);
        }

        // GET: PedidoProdutos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoProduto pedidoProduto = db.PedidoProduto.Find(id);
            if (pedidoProduto == null)
            {
                return HttpNotFound();
            }
            ViewBag.PedidoID = new SelectList(db.Pedido, "Id", "Id", pedidoProduto.PedidoID);
            ViewBag.ProdutoID = new SelectList(db.Produto, "Id", "Nome", pedidoProduto.ProdutoID);
            return View(pedidoProduto);
        }

        // POST: PedidoProdutos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PedidoID,ProdutoID,Valor,Quantidade")] PedidoProduto pedidoProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PedidoID = new SelectList(db.Pedido, "Id", "Id", pedidoProduto.PedidoID);
            ViewBag.ProdutoID = new SelectList(db.Produto, "Id", "Nome", pedidoProduto.ProdutoID);
            return View(pedidoProduto);
        }

        // GET: PedidoProdutos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoProduto pedidoProduto = db.PedidoProduto.Find(id);
            if (pedidoProduto == null)
            {
                return HttpNotFound();
            }
            return View(pedidoProduto);
        }

        // POST: PedidoProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoProduto pedidoProduto = db.PedidoProduto.Find(id);
            db.PedidoProduto.Remove(pedidoProduto);
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
