using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PagedProductDTO
    {
        public ArrayList PagedEntities { get; set; } = new ArrayList();
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
