//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasterLibrary.Models.DataProvider
{
    using System;
    using System.Collections.Generic;
    
    public partial class REVIEW
    {
        public int MARV { get; set; }
        public string NHANXET { get; set; }
        public Nullable<int> MAKH { get; set; }
        public Nullable<int> MASACH { get; set; }
    
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual SACH SACH { get; set; }
    }
}