//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceePubCloud
{
    using System;
    using System.Collections.Generic;
    
    public partial class Genre
    {
        public Genre()
        {
            this.eBook = new HashSet<eBook>();
        }
    
        public int id { get; private set; }
        public string name { get; set; }
    
        public virtual ICollection<eBook> eBook { get; set; }
    }
}
