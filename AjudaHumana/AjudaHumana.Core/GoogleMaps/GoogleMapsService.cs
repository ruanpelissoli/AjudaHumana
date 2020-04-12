using AjudaHumana.Core.Domain;
using AjudaHumana.Core.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.Net;
using System.Xml.Linq;

namespace AjudaHumana.Core.GoogleMaps
{
    public class GoogleMapsService : IGoogleMapsService
    {
        private readonly IConfiguration _configuration;

        private readonly string _key;

        public GoogleMapsService(IConfiguration configuration)
        {
            _configuration = configuration;

            _key = _configuration.GetSection("GoogleMapsKey").Value;
        }

        public GeoLocationViewModel GetLocation(AddressViewModel address)
        {
            var requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={1}&address={0}&sensor=false", Uri.EscapeDataString(address.ToString()), _key);

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());

            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");
            var lat = locationElement.Element("lat");
            var lng = locationElement.Element("lng");

            return new GeoLocationViewModel
            {
                Latitude = double.Parse(lat.Value, CultureInfo.InvariantCulture),
                Longitude = double.Parse(lng.Value, CultureInfo.InvariantCulture)
            };
        }
    }
}
