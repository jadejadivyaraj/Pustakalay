//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pustakalay.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseItems
    {
        public PurchaseItems()
        {
            this.Books = new HashSet<Book>();
        }
    
        public System.Guid Id { get; set; }
    
        public virtual Purchase Purchase { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
