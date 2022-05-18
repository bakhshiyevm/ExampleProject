using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PagedResponse<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public IEnumerable<T> DTOs { get; set; }

        public PagedResponse(int? page, int? pageSize, IEnumerable<T> model)
        {

            Page = (page.HasValue) ? page.Value : 1;
            PageSize = (pageSize.HasValue) ? pageSize.Value : 25;
            DTOs = model;
        }
    }
}
