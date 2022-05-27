using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalogue.Domain.DomainModels
{
    public class PersonRole : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

    }
}
