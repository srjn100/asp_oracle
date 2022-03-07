using Berklee.DAO;
using Berklee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Berklee.Controllers
{
    public class StudentController : Controller
    {
        Entities _db = new Entities();

        // GET: Student
        public ActionResult Index()
        {
            var students = _db.STUDENTs.ToList();
            var viewModel = new List<StudentModel>();
            foreach (STUDENT s in students)
            {
                viewModel.Add(StudentModel.getViewModel(s));
            }
            //List<StudentModel> model = viewModel;
            return View(viewModel);
        }

        // GET: StudentDetails
        public ActionResult StudentDetail(decimal sID)
        {
            var dbModel = _db.STUDENTs.Where(x => x.STUDENTID == sID).FirstOrDefault();
            var viewModel = StudentModel.getViewModel(dbModel);
            viewModel.department = _db.DEPARTMENTs.Where(x => x.DEPARTMENTID == viewModel.department_departmentID).FirstOrDefault().DEPARTMENTNAME;
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult SaveStudent()
        {
            var departments = _db.DEPARTMENTs.Select(x => new SelectListItem
            {
                Text = x.DEPARTMENTNAME,
                Value = x.DEPARTMENTID.ToString()
            }).ToList();
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult SaveStudent(StudentModel model)
        {
            
                if (ModelState.IsValid)
                {
                    var dbModel = model.getDAO();
                    _db.STUDENTs.Add(dbModel);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return View();
            
        }

        [HttpGet]
        public ActionResult UpdateStudent(int sID)
        {
            var dbModel = _db.STUDENTs.Where(x => x.STUDENTID == sID).FirstOrDefault();
            StudentModel model = StudentModel.getViewModel(dbModel);
            model.studentID = sID;

            var departments = _db.DEPARTMENTs.Select(x => new SelectListItem
            {
                Text = x.DEPARTMENTNAME,
                Value = x.DEPARTMENTID.ToString()
            }).ToList();
            ViewBag.Departments = departments;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateStudent(StudentModel model)
        {
            var dbModel = _db.STUDENTs.Where(x => x.STUDENTID == model.studentID).FirstOrDefault();
            if (dbModel != null)
            {
                dbModel.STUDENTNAME = model.studentName;
                dbModel.ADDRESS = model.address;
                dbModel.EMAIL = model.email;
                dbModel.DEPARTMENT_DEPARTMENTID = model.department_departmentID;
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(int sID)
        {
            var dbmodel = _db.STUDENTs.Where(x => x.STUDENTID == sID).FirstOrDefault();
            if (dbmodel != null)
            {
                _db.STUDENTs.Remove(dbmodel);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MapStudentModule(int sID)
        {
            var modules = _db.MODULEs.Select(x => new SelectListItem
            {
                Text = x.MODULENAME,
                Value = x.MODULECODE
            }).ToList();
            ViewBag.Modules = modules;
            ViewBag.sID = sID;
            ViewBag.sName = _db.STUDENTs.Select(x => x.STUDENTID == sID).FirstOrDefault();
            StudentModuleModel tmodel = new StudentModuleModel();
            tmodel.studentID = sID;

            return View(tmodel);
        }
        [HttpPost]
        public ActionResult MapStudentModule(StudentModuleModel model)
        {
            if (ModelState.IsValid)
            {
                var dbModel = model.getDAO();
                _db.STUDENT_MODULE.Add(dbModel);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();

        }

    }
}