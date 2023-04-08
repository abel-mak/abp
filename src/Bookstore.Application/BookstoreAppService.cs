using System;
using System.Collections.Generic;
using System.Text;
using Bookstore.Localization;
using Volo.Abp.Application.Services;

namespace Bookstore;

/* Inherit your application services from this class.
 */
public abstract class BookstoreAppService : ApplicationService
{
    protected BookstoreAppService()
    {

        LocalizationResource = typeof(BookstoreResource);
    }
}
