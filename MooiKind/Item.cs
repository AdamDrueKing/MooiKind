//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MooiKind
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public int NameID { get; set; }
        public int PriceID { get; set; }
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        public Nullable<int> DescriptionID { get; set; }
    
        public virtual Color Color1 { get; set; }
        public virtual Description Description1 { get; set; }
        public virtual Name Name1 { get; set; }
        public virtual Price Price1 { get; set; }
        public virtual Size Size1 { get; set; }
    }
}
