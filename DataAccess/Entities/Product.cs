﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string ImgPath { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }
    }
}
