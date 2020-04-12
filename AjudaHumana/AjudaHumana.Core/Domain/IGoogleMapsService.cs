using AjudaHumana.Core.ViewModels;

namespace AjudaHumana.Core.Domain
{
    public interface IGoogleMapsService
    {
        GeoLocationViewModel GetLocation(AddressViewModel address);
    }
}
