using Berklee.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Berklee.Models
{
    public class PaymentModel
    {
        public decimal paymentID { get; set; }
        public decimal amount { get; set; }
        public DateTime datePaid { get; set; }

        public PAYMENT getDAO()
        {
            return new PAYMENT
            {
                PAYMENTID = paymentID,
                AMOUNT = amount,
                DATEPAID = datePaid
            };
        }

        public static PaymentModel getViewModel(PAYMENT payment)
        {
            return new PaymentModel
            {
                paymentID = payment.PAYMENTID,
                amount = payment.AMOUNT,
                datePaid = payment.DATEPAID
            };
        }
    }
}