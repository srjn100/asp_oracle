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
    
    public partial class ASSIGNMENT_TYPE
    {
        public ASSIGNMENT_TYPE()
        {
            this.ASSIGNMENTs = new HashSet<ASSIGNMENT>();
        }
    
        public decimal TYPEID { get; set; }
        public string TYPENAME { get; set; }
    
        public virtual ICollection<ASSIGNMENT> ASSIGNMENTs { get; set; }
    }
}