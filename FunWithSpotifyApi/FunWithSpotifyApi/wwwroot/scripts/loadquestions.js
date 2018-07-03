var request = new XMLHttpRequest();
request.open('GET', '/questions/get', true);

request.onload = function () {
    if (request.status >= 200 && request.status < 400) {
        var data = JSON.parse(request.responseText);
        var label = document.getElementById("question");
        label.innerHTML = data.question;
    }
};

request.onerror = function () {
};

request.send();