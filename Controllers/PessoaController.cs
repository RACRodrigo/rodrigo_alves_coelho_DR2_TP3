using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rodrigo_alves_coelho_DR2_TP3rodrigo_alves_coelho_DR2_TP3.Models;

namespace rodrigo_alves_coelho_DR2_TP3rodrigo_alves_coelho_DR2_TP3.Controllers
{
    public class PessoaController : Controller
    {

        // 1. *************RETRIEVE ALL Pessoa DETAILS ******************
        // GET: Student
        public ActionResult Index()
        {
            PessoaDBHandle dbhandle = new PessoaDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetPessoa());
        }

        // 2. *************ADD NEW STUDENT ******************
        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Pessoa smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PessoaDBHandle sdb = new PessoaDBHandle();
                    if (sdb.AddPessoa(smodel))
                    {
                        ViewBag.Message = "Pessoa adicionada com sucesso!!!";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // 3. ************* EDIT STUDENT DETAILS ******************
        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            PessoaDBHandle sdb = new PessoaDBHandle();
            return View(sdb.GetPessoa().Find(smodel => smodel.Id == id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pessoa smodel)
        {
            try
            {
                PessoaDBHandle sdb = new PessoaDBHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // 4. ************* DELETE STUDENT DETAILS ******************
        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                PessoaDBHandle sdb = new PessoaDBHandle();
                if (sdb.DeletePessoa(id))
                {
                    ViewBag.AlertMsg = "Pessoa deletada com sucesso!!!";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
