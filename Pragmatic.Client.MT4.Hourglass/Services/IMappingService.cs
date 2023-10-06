namespace Pragmatic.Client.Hourglass.MT4.Services
{
    public interface IMappingService
    {
        void MapMT4PrimitivesToAccount();
        void MapMT4PrimitivesToOrder();
    }
}