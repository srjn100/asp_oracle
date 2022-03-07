using Berklee.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Berklee.Models
{
    public class StudentModuleModel
    {
        public decimal id { get; set; }
        public decimal attendance { get; set; }
        public string moduleCode { get; set; }
        public decimal studentID { get; set; }

        public STUDENT_MODULE getDAO()
        {
            return new STUDENT_MODULE
            {
                ID = id,
                ATTENDANCE = attendance,
                MODULE_MODULECODE = moduleCode,
                STUDENT_STUDENTID = studentID,                
            };
        }

        public static StudentModuleModel getViewModel(STUDENT_MODULE module)
        {
            return new StudentModuleModel
            {
                id = module.ID,
                attendance = (decimal)module.ATTENDANCE,
                moduleCode = module.MODULE_MODULECODE,
                studentID = module.STUDENT_STUDENTID,
                
            };
        }


    }
}