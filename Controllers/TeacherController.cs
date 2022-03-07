using Berklee.DAO;
using Berklee.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Berklee.Controllers
{
    public class TeacherController : Controller
    {
        Entities _db = new Entities();
        // GET: Teacher
        public ActionResult Index()
        {
            var teachers = _db.TEACHERs.ToList();
            var viewModel = new List<TeacherModel>();
            foreach (TEACHER t in teachers)
            {
                viewModel.Add(Models.TeacherModel.getViewModel(t));
            }
            return View(viewModel);
        }

        // GET: Teacher Details
        public ActionResult TeacherDetail(decimal tID)
        { 
            var dbModel = _db.TEACHERs.Where(x => x.TEACHERID == tID).FirstOrDefault();
            var viewModel = TeacherModel.getViewModel(dbModel);

            var moduleList = (from M in _db.MODULEs
                              join TM in _db.TEACHER_MODULE on M.MODULECODE equals TM.MODULE_MODULECODE
                              join T in _db.TEACHERs on TM.TEACHER_TEACHERID equals T.TEACHERID
                              where T.TEACHERID == tID 
                              select new ModuleModel { 
                                moduleCode= M.MODULECODE,
                                moduleName= M.MODULENAME,
                                start = (DateTime)TM.STARTDATE,
                                end = (DateTime)TM.ENDDATE
                              }).ToList();
            viewModel.module = moduleList;
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult SaveTeacher()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult SaveTeacher(TeacherModel model)
        {
            if (ModelState.IsValid)
            {
                var dbModel = model.getDAO();
                _db.TEACHERs.Add(dbModel);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();

        }

        [HttpGet]
        public ActionResult UpdateTeacher(int tID)
        {
            var dbModel = _db.TEACHERs.Where(x => x.TEACHERID == tID).FirstOrDefault();
            TeacherModel model = TeacherModel.getViewModel(dbModel);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateTeacher(TeacherModel model)
        {
            var dbModel = _db.TEACHERs.Where(x => x.TEACHERID == model.teacherID).FirstOrDefault();
            if (dbModel != null)
            {
                dbModel.FULLNAME = model.fullName;
                dbModel.ADDRESS = model.address;
                dbModel.EMAIL = model.email;                
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTeacher(int tID)
        {
            var dbmodel = _db.TEACHERs.Where(x => x.TEACHERID == tID).FirstOrDefault();
            if (dbmodel != null)
            {
                _db.TEACHERs.Remove(dbmodel);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MapTeacherModule(int tID)
        {
            var modules = _db.MODULEs.Select(x => new SelectListItem
            {
                Text = x.MODULENAME,
                Value = x.MODULECODE
            }).ToList();
            ViewBag.Modules = modules;
            ViewBag.tID = tID;
            TeacherModuleModel tmodel = new TeacherModuleModel();
            tmodel.teacherID = tID;
            
            return View(tmodel);
        }
        [HttpPost]
        public ActionResult MapTeacherModule(TeacherModuleModel model)
        {
            if (ModelState.IsValid)
            {
                var dbModel = model.getDAO();
                _db.TEACHER_MODULE.Add(dbModel);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();

        }
    }
}