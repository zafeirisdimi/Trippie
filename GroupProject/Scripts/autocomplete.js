﻿let inputEles = document.querySelectorAll('input[type=search]');

let start;
let end;

console.log(inputEles);

inputEles.forEach((e) =>
    e.addEventListener("input", async (e) => {
        let city = await search(e.currentTarget.value);
        CreateResultDivs(city, e.target);
    })
);

async function search(input) {
    let response = await fetch(
        `http://localhost:8000/autocomplete?input=${input}`
    );

    let results = [];

    if (response.ok) {
        results = await response.json();
        // console.table(results);
    } else {
        console.log("HTTP-Error: " + response.status);
    }

    return results;
}

function CreateResultDivs(cityObjects, inputElement) {
    let div = inputElement.nextElementSibling;
    ClearElementContent(div);

    if (!inputElement.value) return;

    for (const city of cityObjects) {
        let p = document.createElement("p");
        p.innerText = `${city.asciiName}, ${city.countryNameEN}`;
        p.addEventListener("click", (e) => {
            inputElement.value = p.innerText;
            ClearElementContent(div);

            if (inputElement.name === "start") {
                start = city;
            } else if (inputElement.name === "destination") {
                end = city;
            }

        });
        div.append(p);
    }
}

function ClearElementContent(div) {
    while (div.firstChild) {
        div.removeChild(div.firstChild);
    }
}

export {
    start,
    end
}