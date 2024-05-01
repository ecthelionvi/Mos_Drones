using Accessors.DBModels;

namespace Accessors.Accessors
{
    interface IOpenRouteAccessor
    {
        Task RunAsync(AddressDataModel address);
        Task<Coordinate> GetCoordinatesAsync(string path);
    }
}