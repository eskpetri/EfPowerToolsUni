﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace EfPowerToolsUni.Models
{
    public partial class Course
    {
        public Course()
        {
            Grades = new HashSet<Grade>();
        }

        public int Idcourse { get; set; }
        public string? Name { get; set; }
        public short? Greditpoints { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}