using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public enum SortOrder 
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc
    }
    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; }
        public string ImgPath { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string Desc { get; set; }
    }
}
