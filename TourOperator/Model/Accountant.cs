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
    
    public partial class Accountant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Accountant()
        {
            this.Tours = new HashSet<Tours>();
        }
    
        public int AccountantID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int TaxPaymentID { get; set; }
        public int StateReportID { get; set; }
    
        public virtual StateStatisticsReports StateStatisticsReports { get; set; }
        public virtual TaxPayments TaxPayments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tours> Tours { get; set; }
    }
}
