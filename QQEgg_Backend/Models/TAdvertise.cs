﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace QQEgg_Backend.Models
{
    public partial class TAdvertise
    {
        public TAdvertise()
        {
            TAorders = new HashSet<TAorders>();
        }

        public int AdvertiseId { get; set; }
        public string Name { get; set; }
        public decimal? DatePrice { get; set; }

        public virtual ICollection<TAorders> TAorders { get; set; }
    }
}