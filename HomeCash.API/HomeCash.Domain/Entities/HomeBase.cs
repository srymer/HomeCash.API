using System;
using System.Collections.Generic;

namespace HomeCash.Domain.Entities
{
    public class HomeBase
    {
        public Guid HomeBaseId { get; set; }
        public string HomeName { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Cost> Costs { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
    }
}