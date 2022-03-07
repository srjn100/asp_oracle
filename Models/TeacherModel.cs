using Berklee.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Berklee.Models
{
    public class TeacherModel
    {
        public decimal teacherID { get; set; }
        public string fullName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public List<ModuleModel> module { get; set; }
        

        public TEACHER getDAO()
        {
            return new TEACHER
            {
                TEACHERID = teacherID,
                FULLNAME = fullName,
                ADDRESS = address,
                EMAIL = email
            };
        }

        public static TeacherModel getViewModel(TEACHER teacher)
        {
            return new TeacherModel
            {
                teacherID = teacher.TEACHERID,
                fullName = teacher.FULLNAME,
                address = teacher.ADDRESS,
                email = teacher.EMAIL,
            };
        }
    }
}