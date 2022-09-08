import { start, end } from "./autocomplete.js";

const newCache = await caches.open("new-cache");

const mapOverlay = document.querySelector('.map-overlay');
const loading = document.querySelector('.spinner-border');

let placesInTrip = [];

let startBtn = document.querySelector('#start-button');
startBtn.addEventListener("click", (e) => {

    let checked = GetCheckedTypes();
    console.log(checked);
    //e.preventDefault();
    if (start && end && checked.length) {
        initMap(e)
    } else {
        console.log("Start or end is not set");
    }
})


let inputForm = document.querySelector('#input-from');
inputForm.addEventListener("submit", async (e) => {
    e.preventDefault();

    let types = GetCheckedTypes();

    let trip = {
        start: start,
        end: end,
        creationDate: Date.now,
        types: [...types],
        places: [...placesInTrip]
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

async function GetDirections(startPoint, endPoint) {
    let directionService = new google.maps.DirectionsService();

    let startCoordinates = new google.maps.LatLng(
        startPoint.coordinates.latitude,
        startPoint.coordinates.longitude
    );
    let endCoordinates = new google.maps.LatLng(
        endPoint.coordinates.latitude,
        endPoint.coordinates.longitude
    );

    let request = {
        origin: startCoordinates,
        destination: endCoordinates,
        travelMode: "DRIVING",
    };

    let directions;

    await directionService.route(request, (result, status) => {
        if (status == "OK") {
            directions = result;
        }
    });

    return directions;
}

async function GetPlaces(directions) {
    let overview_path = directions.routes[0].overview_path.map((c) => {
        let coordinate = c.toJSON();
        return { longitude: coordinate.lng, latitude: coordinate.lat };
    });

    let types = GetCheckedTypes();

    let dto = {
        pathOverview: overview_path,
        placeTypes: types
    }

    let response = await fetch(
        "https://localhost:44397/api/places/getplacesalongpath",
        {
            method: "POST",
            headers: {
                "Content-Type": "application/json;charset=utf-8",
            },
            body: JSON.stringify(dto),
        }
    );

    let result = await response.json();

    return result;
}

async function SetMarkers(map, places) {

    const infoWindow = new google.maps.InfoWindow();

    let markers = [];

    places.forEach((place) => {
        const marker = new google.maps.Marker({
            position: { lat: place.point.lat, lng: place.point.lon },
            // position: { lat: place.latitude, lng: place.longitude }, // plot overview_path
            map,
            title: place.name,
        });

        marker.addListener("click", async () => {
            const placeInfo = await GetPlaceInfo(place);
            let infoWindowElement = CreateWindowInfoElement(placeInfo);

            infoWindow.close();
            infoWindow.setContent(infoWindowElement);
            infoWindow.open(marker.getMap(), marker);
        });

        markers.push(marker);
    });

    return markers;
}

async function GetPlaceInfo(place) {
    let url = `https://api.opentripmap.com/0.1/en/places/xid/${place.xid}?apikey=5ae2e3f221c38a28845f05b6068096737a6bd1b9a215367ca1d1bd33`;

    let placeInfo = await newCache.match(url);

    if (!placeInfo) {
        let response = await fetch(url);
        console.log("Not cached");
        if (response.ok) {
            placeInfo = response;
            newCache.put(url, response.clone());
        } else {
            alert("HTTP-Error: " + response.status);
        }
    }

    return placeInfo.json();
}

function CreateWindowInfoElement(place) {

    let map = document.querySelector("#map");

    let container = document.createElement("div");
    container.classList.add('infoWindow');
    map.append(container);

    let image = document.createElement("img");
    image.src = place.preview.source;
    container.append(image);

    let headerContainer = document.createElement("div");
    headerContainer.classList.add("header-container");

    let title = document.createElement("p");
    title.classList.add('h4')
    title.textContent = place.name;
    headerContainer.append(title);

    let anchor = document.createElement("a");
    anchor.innerHTML = `<a href="https://www.google.com/search?q=${place.name}" target="_blank">Open in Google</a>`;
    headerContainer.append(anchor);

    container.append(headerContainer);

    //let kindsList = document.createElement("div");
    //kindsList.classList.add('kinds-list');

    //let kindsItems = kindsParsed(place.kinds).map((kind) => {
    //    let listItem = document.createElement("p");
    //    listItem.textContent = kind;

    //    return listItem;
    //});
    //kindsItems.forEach((kind) => {
    //    kindsList.append(kind);
    //});
    //container.append(kindsList);

    let description = document.createElement("p");
    description.innerHTML = place.wikipedia_extracts.html;
    container.append(description);

    let addBtnContainer = document.createElement("div");
    addBtnContainer.classList.add("d-flex");
    addBtnContainer.classList.add("justify-content-center");

    let addBtn = document.createElement("button");

    addBtn.classList.add('btn');
    addBtn.classList.add('btn-dark');


    addBtn.setAttribute('type', 'button');
    addBtn.textContent = "Add to Trip";
    addBtn.addEventListener("click", () => {
        if (!placesInTrip.find((p) => p.xid === place.xid))
            placesInTrip.push(place);

        if (!PlaceRowInList(place)) {
            CreatePlaceRow(place);
        }

        let addTripBtn = document.querySelector('#add-trip');
        addTripBtn.disabled = false;

        console.log(placesInTrip);
    });

    addBtnContainer.append(addBtn);

    container.append(addBtnContainer);



    return container;
}

let kindsParsed = (kinds) => {
    let kindsSplit = kinds.split(",");

    let parsed = kindsSplit.map((kind) => {
        let capitalized = kind.charAt(0).toUpperCase() + kind.slice(1);

        let split = capitalized.split("_");

        return split.join(" ");
    });

    return parsed;
};


function CreatePlaceRow(place) {
    let placeRow = document.createElement("li");
    placeRow.setAttribute('key', place.xid);
    placeRow.classList.add('list-group-item');
    placeRow.classList.add('d-flex');
    placeRow.classList.add('justify-content-between');

    let placeInfo = document.createElement("div");
    placeInfo.textContent = place.name;


    let deleteBtn = document.createElement("span");
    deleteBtn.innerHTML = '<button class="delete-place"><i class="fa fa-trash" aria-hidden="true"></i></button>'
    deleteBtn.addEventListener('click', () => {
        let row = deleteBtn.parentElement;
        let id = row.getAttribute('key');
        row.remove();

        let index = placesInTrip.map(p => p.xid)
            .indexOf(id);

        placesInTrip.splice(index, 1);


        let addTripBtn = document.querySelector('#add-trip');

        if (placesInTrip.length == 0)
            addTripBtn.disabled = true;

        console.log(placesInTrip);
    });

    placeRow.append(placeInfo);
    placeRow.append(deleteBtn);

    let ol = document.querySelector('#places-list');

    ol.append(placeRow);


}

function PlaceRowInList(place) {
    let list = document.querySelector('#places-list')

    let rows = Array.from(list.children);

    if (rows.length == 0)
        return false;

    console.log(rows);
    let ids = rows.map(r => r.getAttribute('key'));
    console.log(ids);

    return ids.some(id => place.xid === id);
}

function GetCheckedTypes() {
    let checkboxes = Array.from(document.querySelectorAll('input[type=checkbox'));
    let checked = [];

    checkboxes.forEach(c => {
        if (c.checked)
            checked.push(+c.value);
    });

    return checked;
}