using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalogue.Domain.DomainModels
{
    public class Role : BaseEntity
    {
        public string Type { get; set; }


        public virtual ICollection<PersonRole> PersonRoles { get; set; }
    }
}
