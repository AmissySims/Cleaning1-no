//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cleaning1.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supply
    {
        public int SupplierId { get; set; }
        public int DetergentId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Quanity { get; set; }
    
        public virtual Detergent Detergent { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
