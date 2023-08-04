namespace Pragmatic.Client.MT4.Hourglass.Services
{
    public interface IMappingService
    {
        void MapMT4PrimitivesToAccount();
        void MapMT4PrimitivesToOrder();
    }
}