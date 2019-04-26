using System;
using NHibernate.AspNetCore.Identity;

namespace NHibernate.AspNetCore.Identity_Sample_API.DomainObject
{
    public class ApplicationUser : IdentityUser
    {
        public virtual DateTime CreateTime { get; set; }

        public virtual DateTime? LastLogin { get; set; }

        public virtual int LoginCount { get; set; }
    }
}