using Volo.Abp.Modularity;

namespace Bookstore;

[DependsOn(
    typeof(BookstoreApplicationModule),
    typeof(BookstoreDomainTestModule)
    )]
public class BookstoreApplicationTestModule : AbpModule
{

}
