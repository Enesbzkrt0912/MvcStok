//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Satıslar
    {
        public int SatısID { get; set; }
        public int Urun { get; set; }
        public int Musteri { get; set; }
        public short Adet { get; set; }
        public short Fiyat { get; set; }
    
        public virtual Musteriler Musteriler { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
