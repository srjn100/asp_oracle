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
    
    public partial class MODULE
    {
        public MODULE()
        {
            this.ASSIGNMENTs = new HashSet<ASSIGNMENT>();
            this.STUDENT_MODULE_PAYMENT = new HashSet<STUDENT_MODULE_PAYMENT>();
            this.STUDENT_MODULE = new HashSet<STUDENT_MODULE>();
            this.TEACHER_MODULE = new HashSet<TEACHER_MODULE>();
        }
    
        public string MODULECODE { get; set; }
        public string MODULENAME { get; set; }
        public string SYLLABUS { get; set; }
    
        public virtual ICollection<ASSIGNMENT> ASSIGNMENTs { get; set; }
        public virtual ICollection<STUDENT_MODULE_PAYMENT> STUDENT_MODULE_PAYMENT { get; set; }
        public virtual ICollection<STUDENT_MODULE> STUDENT_MODULE { get; set; }
        public virtual ICollection<TEACHER_MODULE> TEACHER_MODULE { get; set; }
    }
}