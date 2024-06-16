using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PagedEntityDTO<TEntity>
    {
        public List<TEntity> PagedEntities { get; set; } = new List<TEntity>();
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
