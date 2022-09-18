let radiusInput = document.querySelector('input[name=radius]');
let radiusValue = document.querySelector('input[name=radius] ~ p');
radiusValue.textContent = radiusInput.value;

radiusInput.addEventListener('input', () => {
    radiusValue.textContent = radiusInput.value;
});

let pointsInput = document.querySelector('input[name=points]');
let pointsValue = document.querySelector('input[name=points] ~ p');
pointsValue.textContent = pointsInput.value;

pointsInput.addEventListener('input', () => {
    pointsValue.textContent = pointsInput.value;
});