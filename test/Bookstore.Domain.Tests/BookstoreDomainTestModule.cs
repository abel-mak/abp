using Bookstore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Bookstore;

[DependsOn(
    typeof(BookstoreEntityFrameworkCoreTestModule)
    )]
public class BookstoreDomainTestModule : AbpModule
{

}
