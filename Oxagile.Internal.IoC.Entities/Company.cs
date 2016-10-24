using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oxagile.Internal.IoC.Entities
{
    public class Company : Entity
    {
        [StringLength(16)]
        public string Name { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
    }
}