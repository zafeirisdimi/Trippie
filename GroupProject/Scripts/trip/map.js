import { start, end } from "./autocomplete.js";
import GetCheckedTypes from "./types.js"
import GetDirections from "./directions.js";
import { GetPlaces } from "./places.js";
import { SetMarkers, placesInTrip } from "./markers.js";


export async function initMap(event) {
    event.preventDefault();

    loading.hidden = false;

    let directionRenderer = new google.maps.DirectionsRenderer();

    let map = new google.maps.Map(document.getElementById("map"));

    directionRenderer.setMap(map);

    let directions = await GetDirections(start, end);

    let places = await GetPlaces(directions);

    console.log(places);
    directionRenderer.setDirections(directions);

    let markers = await SetMarkers(map, places);

    const markerCluster = new markerClusterer.MarkerClusterer({ map, markers });

    mapOverlay.hidden = true;
    loading.hidden = true;
}

const mapOverlay = document.querySelector('.map-overlay');
const loading = document.querySelector('.spinner-border');

let startBtn = document.querySelector('#start-button');
startBtn.addEventListener("click", (e) => {
    let checked = GetCheckedTypes();
    console.log(checked);
    if (start && end && checked.length) {
        initMap(e)
    } else {
        alert("Start, destination and place types must be set.");
    }
})

let inputForm = document.querySelector('#input-from');
inputForm.addEventListener("submit", async (e) => {
    e.preventDefault();

    let createTripBtn = e.target.querySelector('button[type=submit]');

    if (createTripBtn.getAttribute('isRegistered')) {
        StoreTripInDB();
    } else {
        OpenTripInGoogleMaps();
    }
});


function OpenTripInGoogleMaps() {

    let startQueryParam = `${start.coordinates.latitude}%2c${start.coordinates.longitude}`;
    let destinationQueryParam = `${end.coordinates.latitude}%2c${end.coordinates.longitude}`;

    let waypointQueryParams = placesInTrip.map(p => `${p.point.lat}%2c${p.point.lon}`);
    let waypoints = waypointQueryParams.join('%7C');


    let googleRedirect = `https://www.google.com/maps/dir/?api=1&origin=${startQueryParam}&destination=${destinationQueryParam}&travelmode=driving&waypoints=${waypoints}`;

    window.location.href = googleRedirect;
}


function StoreTripInDB() {
    let types = GetCheckedTypes();

    let placeDtos = placesInTrip.map(p => {
        return {
            xid: p.xid,
            name: p.name,
            rate: p.rate,
            imageUrl: p.preview.source,
            info: p.wikipedia_extracts.text,
            latitude: p.point.lat,
            longitude: p.point.lon
        }
    });

    let startDto = {
        geonameID: start.geonameID,
        name: start.asciiName,
        country: start.countryNameEN,
        longitude: start.coordinates.longitude,
        latitude: start.coordinates.latitude
    }

    let endDto = {
        geonameID: end.geonameID,
        name: end.asciiName,
        country: end.countryNameEN,
        longitude: end.coordinates.longitude,
        latitude: end.coordinates.latitude
    }

    let trip = {
        start: startDto,
        end: endDto,
        creationDate: new Date().toJSON(),
        chosenPlaceTypes: [...types],
        places: [...placeDtos]
    }

    fetch('https://localhost:44397/Trip/CreateTrip', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(trip)
    }).then((response) => response.json())
        .then((url) => {
            window.location.href = url.redirectToUrl;
        })
}


