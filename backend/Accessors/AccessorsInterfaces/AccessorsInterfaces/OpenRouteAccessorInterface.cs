using Accessors.DBModels;

namespace Accessors.Accessors
{
    interface IOpenRouteAccessor
    {
        static async Task RunAsync(AddressDataModel address);
        static async Task<Coordinate> GetCoordinatesAsync(string path);
    }
}