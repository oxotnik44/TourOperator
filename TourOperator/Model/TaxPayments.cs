//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TourOperator.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaxPayments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaxPayments()
        {
            this.Accountant = new HashSet<Accountant>();
        }
    
        public int TaxPaymentID { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string TaxName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Accountant> Accountant { get; set; }
    }
}
