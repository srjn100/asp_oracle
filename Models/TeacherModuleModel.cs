using Berklee.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Berklee.Models
{
    public class TeacherModuleModel
    {
        public decimal id { get; set; }
        public string moduleCode { get; set; }
        public decimal teacherID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public TEACHER_MODULE getDAO()
        {
            return new TEACHER_MODULE
            {
                ID = id,
                MODULE_MODULECODE = moduleCode,
                TEACHER_TEACHERID = teacherID,
                STARTDATE = startDate,
                ENDDATE = endDate
            };
        }

        public static TeacherModuleModel getViewModel(TEACHER_MODULE module)
        {
            return new TeacherModuleModel
            {
                id = module.ID,
                moduleCode = module.MODULE_MODULECODE,
                teacherID = module.TEACHER_TEACHERID,
                startDate = (DateTime)module.STARTDATE,
                endDate = (DateTime)module.ENDDATE
            };
        }


    }
}