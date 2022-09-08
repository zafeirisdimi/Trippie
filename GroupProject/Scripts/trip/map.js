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

    if (start && end && checked.length) {
        initMap(e)
    } else {
        alert("Start, destination and place types must be set.");
    }
})

let inputForm = document.querySelector('#input-from');
inputForm.addEventListener("submit", async (e) => {
    e.preventDefault();

    let types = GetCheckedTypes();

    let placeDtos = placesInTrip.map(p => {
        return {
            xid: p.xid,
            name: p.name,
            rate: p.rate,
            imageUrl: p.preview.source,
            info: p.wikipedia_extracts.text,
            coordinates: {
                latitude: p.point.lat,
                longitude: p.point.lon
            }
        }
    });


    let trip = {
        start: start,
        end: end,
        creationDate: Date.now,
        types: [...types],
        places: [...placeDtos]
    }
    console.log(trip);
    // Need to specify the CREATE action method from the controller
    fetch('/UnregisteredUser/Trip/Action', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(trip)
    });
});


