using System.Threading.Tasks;

namespace SSDCPortal.Infrastructure.Storage
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
        Task EnsureAdminIdentitiesAsync();
    }
}