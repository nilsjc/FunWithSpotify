var Glob = Glob || {};
window.onload = function () {
    slidersInit();
}

function slidersInit() {
    Glob.sliders = document.getElementsByClassName("slider");
    noUiSlider.create(Glob.sliders[0], {
        start: 0,
        connect: true,
        orientation: 'vertical',
        range: {
            'min': 0,
            'max': 127
        }
    });
    Glob.sliders[0].noUiSlider.on('slide', moveSlider);
}

function moveSlider() {
    var number = Glob.sliders[0].noUiSlider.get();
    number = number / 255;
}