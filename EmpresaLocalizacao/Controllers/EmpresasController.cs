using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EmpresaLocalizacao.Context;
using EmpresaLocalizacao.Models;

namespace EmpresaLocalizacao.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly EmpresaLocalizacaoContext db = new EmpresaLocalizacaoContext();

        public ActionResult Localizacao()
        {
            ViewBag.EmpresaId = new SelectList(db.Empresas.ToList(), "EmpresaId", "Nome");
            return View();
        }

        public JsonResult LocalizacaoJson(string empresaId)
        {
            ViewBag.EmpresaId = new SelectList(db.Empresas.ToList(), "EmpresaId", "Nome", empresaId);
            var id = Convert.ToInt32(empresaId);
            var empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return Json(new {Result = "Error"}, JsonRequestBehavior.AllowGet);
            }
            var log = empresa.Logradouro.Replace(' ', '+');

            //var endereco = log + "," + empresa.Numero + "," + empresa.Cep;
            var endereco = empresa.Cep;

            return Json(empresa, JsonRequestBehavior.AllowGet);
        }

        // GET: Empresas
        public ActionResult Index()
        {
            return View(db.Empresas.ToList());
        }

        // GET: Empresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpresaId,Nome,Cidade,Logradouro,Cep,Numero")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Empresas.Add(empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpresaId,Nome,Cidade,Logradouro,Cep,Numero")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var empresa = db.Empresas.Find(id);
            db.Empresas.Remove(empresa);
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