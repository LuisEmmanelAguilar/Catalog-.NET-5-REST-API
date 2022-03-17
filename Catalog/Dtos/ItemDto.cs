using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Dtos
{
    public record ItemDto
    {
        public Guid Id { get; init; } 
        public String Name { get; init; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; init; }


    }
}
