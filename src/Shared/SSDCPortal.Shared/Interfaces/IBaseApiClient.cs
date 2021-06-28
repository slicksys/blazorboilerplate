using Breeze.Sharp;
using System.Threading.Tasks;

namespace SSDCPortal.Shared.Interfaces
{
    public interface IBaseApiClient
    {
        void AddEntity(IEntity entity);

        void RemoveEntity(IEntity entity);

        void ClearEntitiesCache();

        void CancelChanges();

        Task SaveChanges();
    }
}
