using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomadAppWf.Models
{
    public class Subscription : Entity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
