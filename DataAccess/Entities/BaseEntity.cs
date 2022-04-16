using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
