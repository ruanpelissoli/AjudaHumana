function setMap(element, lat, long) {
    var map;
    var marker = { lat: lat, lng: long };
    map = new google.maps.Map(element, {
        center: marker,
        zoom: 15
    });

   new google.maps.Marker({ position: marker, map: map });
}