﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace QQEgg_Backend.Models
{
    public partial class TCategory
    {
        public TCategory()
        {
            TPsiteRoom = new HashSet<TPsiteRoom>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TPsiteRoom> TPsiteRoom { get; set; }
    }
}