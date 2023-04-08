using Bookstore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Bookstore.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BookstoreEntityFrameworkCoreModule),
    typeof(BookstoreApplicationContractsModule)
    )]
public class BookstoreDbMigratorModule : AbpModule
{

}
