using Berklee.DAO;
using Berklee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Berklee.Controllers
{
    public class ModuleController : Controller
    {
        Entities _db = new Entities();
        // GET: Module
        public ActionResult Index()
        {
            var modules = _db.MODULEs.ToList();
            var viewModel = new List<ModuleModel>();
            foreach (MODULE m in modules)
            {
                viewModel.Add(ModuleModel.getViewModel(m));
            }            
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult SaveModule()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult SaveModule(ModuleModel model)
        {

            if (ModelState.IsValid)
            {
                var dbModel = model.getDAO();
                _db.MODULEs.Add(dbModel);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult UpdateModule(string mCode)
        {
            var dbModel = _db.MODULEs.Where(x => x.MODULECODE == mCode).FirstOrDefault();
            ModuleModel model = ModuleModel.getViewModel(dbModel);
            model.mCode = mCode;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateModule(ModuleModel model)
        {
            var dbModel = _db.MODULEs.Where(x => x.MODULECODE == model.moduleCode).FirstOrDefault();
            if (dbModel != null && ModelState.IsValid)
            {
                dbModel.MODULECODE = model.moduleCode;
                dbModel.MODULENAME = model.moduleName;
                dbModel.SYLLABUS = model.syllabus;
                
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteModule(string mCode)
        {
            var dbmodel = _db.MODULEs.Where(x => x.MODULECODE == mCode).FirstOrDefault();
            if (dbmodel != null)
            {
                _db.MODULEs.Remove(dbmodel);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}