// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace EfPowerToolsUni.Models
{
    public partial class Department
    {
        public Department()
        {
            Teachers = new HashSet<Teacher>();
        }

        public short Iddepartment { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}