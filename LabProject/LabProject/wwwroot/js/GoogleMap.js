// Initialize and add the map
function initMap() {
    // The location of Uluru
    const uluru = { lat: 39.557191, lng: - 7.8536599 };

    // The map, centered at Uluru
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 7,
        center: uluru,
    });


  
}