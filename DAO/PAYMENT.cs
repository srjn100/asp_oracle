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
    
    public partial class PAYMENT
    {
        public PAYMENT()
        {
            this.STUDENT_MODULE_PAYMENT = new HashSet<STUDENT_MODULE_PAYMENT>();
        }
    
        public decimal PAYMENTID { get; set; }
        public decimal AMOUNT { get; set; }
        public System.DateTime DATEPAID { get; set; }
    
        public virtual ICollection<STUDENT_MODULE_PAYMENT> STUDENT_MODULE_PAYMENT { get; set; }
    }
}
