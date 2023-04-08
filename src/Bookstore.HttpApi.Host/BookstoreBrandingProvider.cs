using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Bookstore;

[Dependency(ReplaceServices = true)]
public class BookstoreBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Bookstore";
}
