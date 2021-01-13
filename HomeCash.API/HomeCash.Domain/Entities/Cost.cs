using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCash.Domain.Entities
{
    public class Cost
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid GeneratedByUserId { get; set; }
        public Guid CreatedByUserId { get; set; }
        public double Amount { get; set; }        
        public Guid HomeBaseId { get; set; }
        public int ShopId { get; set; }

        public virtual HomeBase HomeBase { get; set; }


    }
}
