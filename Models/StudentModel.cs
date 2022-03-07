using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Berklee.DAO;

namespace Berklee.Models
{
    public class StudentModel
    {
        public decimal studentID { get; set; }
        public string studentName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public decimal department_departmentID { get; set; }
        public string department { get; set; }

        public STUDENT getDAO()
        {
            return new STUDENT
            {
                STUDENTID = studentID,
                STUDENTNAME = studentName,
                ADDRESS = address,
                EMAIL = email,
                DEPARTMENT_DEPARTMENTID = department_departmentID

            };
        }

        public static StudentModel getViewModel(STUDENT student)
        {
            return new StudentModel
            {
                studentID = student.STUDENTID,
                studentName = student.STUDENTNAME,
                address = student.ADDRESS,
                email = student.EMAIL,
                department_departmentID = student.DEPARTMENT_DEPARTMENTID
                
            };
        }
    }
}