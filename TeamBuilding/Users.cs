//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeamBuilding
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Projects = new HashSet<Projects>();
            this.Projects1 = new HashSet<Projects>();
            this.Projects2 = new HashSet<Projects>();
            this.Classes = new HashSet<Classes>();
            this.Skills = new HashSet<Skills>();
        }
    
        public int UsrId { get; set; }
<<<<<<< HEAD
        public string Login { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
=======
<<<<<<< HEAD
        public string Name { get; set; }
=======
        public string Login { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
>>>>>>> master
        public string RegMail { get; set; }
        public string Password { get; set; }
        public string PicturePath { get; set; }
        public Nullable<System.DateTime> Registered { get; set; }
        public Nullable<int> ContactId { get; set; }
        public Nullable<int> RequetId { get; set; }
        public Nullable<int> LikedPrjtId { get; set; }
    
        public virtual Contacts Contacts { get; set; }
<<<<<<< HEAD
        public virtual LikedProjects LikedProjects { get; set; }
=======
<<<<<<< HEAD
        public virtual LikedProjects LikedProjects { get; set; }
=======
>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
>>>>>>> master
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Projects> Projects { get; set; }
        public virtual Requests Requests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Projects> Projects1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Projects> Projects2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Classes> Classes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skills> Skills { get; set; }
    }
}
