# NHibernate.AspNetCore.Identity Sample API

```PowerShell
Install-Package NHibernate
Install-Package NHibernate.NetCore
Install-Package NHibernate.AspNetCore.Identity
```


### NHibernate ###

```C#
public class Startup {

    public void ConfigureServices(
        IServiceCollection services
    ) {
         var cfg = new Configuration();
            var file = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "hibernate.config"
            );
            cfg.Configure(file);
            cfg.AddIdentityMappingsForSqlServer();
            cfg.AddAssembly("NHibernate.AspNetCore.Identity Sample API");

            services.AddHibernate(cfg);
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<ApplicationRole>()
                .AddHibernateStores();

    }
}
```
