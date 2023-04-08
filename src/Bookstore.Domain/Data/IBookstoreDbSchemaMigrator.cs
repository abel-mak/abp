using System.Threading.Tasks;

namespace Bookstore.Data;

public interface IBookstoreDbSchemaMigrator
{
    Task MigrateAsync();
}
