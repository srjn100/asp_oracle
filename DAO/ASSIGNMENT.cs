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
    
    public partial class ASSIGNMENT
    {
        public decimal ASSIGNMENTID { get; set; }
        public string TITLE { get; set; }
        public string MODULE_MODULECODE { get; set; }
        public decimal ASSIGNMENT_TYPE_TYPEID { get; set; }
    
        public virtual ASSIGNMENT_TYPE ASSIGNMENT_TYPE { get; set; }
        public virtual MODULE MODULE { get; set; }
    }
}