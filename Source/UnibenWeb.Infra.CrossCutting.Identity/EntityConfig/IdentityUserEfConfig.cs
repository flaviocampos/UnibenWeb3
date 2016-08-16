using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UnibenWeb.Infra.CrossCutting.Identity.EntityConfig
{
    class IdentityUserEfConfig : EntityTypeConfiguration<IdentityUser>
    {
        public IdentityUserEfConfig()
        {
            ToTable("IdentityUsers");
            HasKey(p => p.Id);
        }
    }
}
