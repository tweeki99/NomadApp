using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomadAppWf.Models
{
    public class Getting : Entity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid EditionId { get; set; }
        public virtual Edition Edition { get; set; }
        public bool IsDelivered { get; set; }
    }
}
