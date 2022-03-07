using Berklee.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Berklee.Models
{
    public class DepartmentModel
    {
        public decimal departmentID { get; set; }
        public string departmentName { get; set; }
        public string email { get; set; }
        public string extension { get; set; }

        public DEPARTMENT getDAO()
        {
            return new DEPARTMENT { 
                DEPARTMENTID = departmentID,
                DEPARTMENTNAME = departmentName,
                EMAIL = email,
                EXTENSION = extension
            };
        }

        public static DepartmentModel getViewModel(DEPARTMENT department)
        {
            return new DepartmentModel {
               departmentID = department.DEPARTMENTID,
               departmentName = department.DEPARTMENTNAME,
               email = department.EMAIL,
               extension = department.EXTENSION
            };
        }
    }
}