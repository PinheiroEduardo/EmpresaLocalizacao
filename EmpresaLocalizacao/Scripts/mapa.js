var geocoder;
var map;
var marker;

function initialize() {
    var latlng = new google.maps.LatLng(-18.8800397, -47.05878999999999);
    var options = {
        zoom: 3,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    map = new google.maps.Map(document.getElementById("mapa"), options);

    geocoder = new google.maps.Geocoder();

    marker = new google.maps.Marker({
        map: map,
        draggable: true
    });

    marker.setPosition(latlng);
}

function converterEndereco(endereco) {
    geocoder.geocode({ 'address': endereco + ', Brasil', 'region': 'BR' }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            if (results[0]) {
                var log = results[0].formatted_address;
                console.log(log);
                $('#txtEndereco').text(log);
                var latitude = results[0].geometry.location.lat();
                var longitude = results[0].geometry.location.lng();
                
                var location = new google.maps.LatLng(latitude, longitude);
                marker.setPosition(location);
                map.setCenter(location);
                map.setZoom(18);
                google.maps.event.addDomListener(window, 'resize', this);
                google.maps.event.addDomListener(window, 'load', this);
            }
        }
    });
}



$(document).ready(function () {
    initialize();
});
