
namespace EMPLOYEES.Repository
{
    public interface IRepositoryMappingService
    {
        TDestination Map<TDestination>(object source);
    }
}
