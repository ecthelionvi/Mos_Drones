using Accessors.Address.Models;

namespace Accessors.API.OpenRoute
{
    public interface IOpenRouteAccessor
    {
        Task<Coordinate> GetCoordinatesAsync(AddressDataModel address);
    }
}