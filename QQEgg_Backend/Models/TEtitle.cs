﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace QQEgg_Backend.Models
{
    public partial class TEtitle
    {
        public TEtitle()
        {
            TEvaluations = new HashSet<TEvaluations>();
        }

        public int TitleId { get; set; }
        public string TitleName { get; set; }

        public virtual ICollection<TEvaluations> TEvaluations { get; set; }
    }
}