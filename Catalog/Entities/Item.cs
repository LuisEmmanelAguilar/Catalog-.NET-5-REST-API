using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Entities
{
    // Record for immutable objects
    public record Item
    {
        public Guid Id { get; init; } // init-only properties
        public String Name { get; init; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; init; }

    }
}
