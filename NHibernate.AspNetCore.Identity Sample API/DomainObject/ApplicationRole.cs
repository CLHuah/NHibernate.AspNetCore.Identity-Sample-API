using NHibernate.AspNetCore.Identity;

namespace NHibernate.AspNetCore.Identity_Sample_API.DomainObject
{
    public class ApplicationRole : IdentityRole
    {
        public virtual string Description { get; set; }
    }
}