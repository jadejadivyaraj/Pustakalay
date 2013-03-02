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
    
    public partial class Book
    {
        public Book()
        {
            this.Earning = 0;
            this.PurchaseCost = 0;
        }
    
        public System.Guid Id { get; set; }
        public Nullable<long> Isbn { get; set; }
        public int Price { get; set; }
        public int Earning { get; set; }
        public Nullable<System.Guid> LendId { get; set; }
        public int PurchaseCost { get; set; }
    
        public virtual BookInfo Details { get; set; }
        public virtual PurchaseItems PurchaseItem { get; set; }
        public virtual Lend Lend { get; set; }
    }
}
