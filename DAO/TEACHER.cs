//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Berklee.DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class TEACHER
    {
        public TEACHER()
        {
            this.STUDENT_TO_TEACHER = new HashSet<STUDENT_TO_TEACHER>();
            this.TEACHER_DEPARTMENT = new HashSet<TEACHER_DEPARTMENT>();
            this.TEACHER_MODULE = new HashSet<TEACHER_MODULE>();
        }
    
        public decimal TEACHERID { get; set; }
        public string FULLNAME { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
    
        public virtual ICollection<STUDENT_TO_TEACHER> STUDENT_TO_TEACHER { get; set; }
        public virtual ICollection<TEACHER_DEPARTMENT> TEACHER_DEPARTMENT { get; set; }
        public virtual ICollection<TEACHER_MODULE> TEACHER_MODULE { get; set; }
    }
}
