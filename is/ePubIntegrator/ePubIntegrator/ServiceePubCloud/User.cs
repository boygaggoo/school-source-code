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
    
    public partial class User
    {
        public User()
        {
            this.Bookmark = new HashSet<Bookmark>();
            this.Access = new HashSet<Access>();
            this.Favourite = new HashSet<Favourite>();
        }
    
        public int id { get; private set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string username { get; set; }
        public string password { get; internal set; }
        public double lastLogin { get; set; }
    
        public virtual ICollection<Bookmark> Bookmark { get; set; }
        public virtual ICollection<Access> Access { get; set; }
        public virtual ICollection<Favourite> Favourite { get; set; }
    }
}
