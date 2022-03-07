using Berklee.DAO;
using Berklee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Berklee.Controllers
{
    public class DepartmentController : Controller
    {
        Entities _db = new Entities();
        // GET: Teacher
        public ActionResult Index()
        {
            var departments = _db.DEPARTMENTs.ToList();
            var viewModel = new List<DepartmentModel>();
            foreach (DEPARTMENT d in departments)
            {
                viewModel.Add(DepartmentModel.getViewModel(d));
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveDepartment(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                var dbModel = model.getDAO();
                _db.DEPARTMENTs.Add(dbModel);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();

        }

        [HttpGet]
        public ActionResult UpdateDepartment(int dID)
        {
            var dbModel = _db.DEPARTMENTs.Where(x => x.DEPARTMENTID == dID).FirstOrDefault();
            DepartmentModel model = DepartmentModel.getViewModel(dbModel);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(DepartmentModel model)
        {
            var dbModel = _db.DEPARTMENTs.Where(x => x.DEPARTMENTID == model.departmentID).FirstOrDefault();
            if (dbModel != null)
            {
                dbModel.DEPARTMENTNAME = model.departmentName;
                dbModel.EMAIL = model.email;
                dbModel.EXTENSION = model.extension;
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int dID)
        {
            var dbmodel = _db.DEPARTMENTs.Where(x => x.DEPARTMENTID == dID).FirstOrDefault();
            if (dbmodel != null)
            {
                _db.DEPARTMENTs.Remove(dbmodel);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}