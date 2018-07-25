var startUp = function startapplication() {
    if (typeof (Storage) === "undefined") {
        alert("No session storage. You cannot use this application.");
        return;
    }
    sessionStorage.actualQuestionId = 0;
    getQuestion();
}();

function selectButton(selectedValue) {
    //Create object to send and store locally
    var result = {
        id: sessionStorage.actualQuestionId,
        value: selectedValue
    }
    saveDataToLocalStorage(result);
}

function saveDataToLocalStorage(data) {
    var array = [];
    if (sessionStorage.getItem('answers') === null) {
        array.push(data);
        sessionStorage.setItem('answers', JSON.stringify(array));
    } else {
        array = JSON.parse(sessionStorage.getItem('answers'));
        array.push(data);
        sessionStorage.setItem('answers', JSON.stringify(array));
    }

    if (array.length > 4) {
        // To be selectable later
        var select = document.getElementById("genre");
        var genre = select.options[select.selectedIndex].value;
        postAnswer(genre);
    }
    else {
        //Get new question from server
        getQuestion();
    }
    
}

function postAnswer(genre) {
    window.location.href = "/results/index?genre=" + genre
        + "&result=" + createFriendlyResult();
}

function createFriendlyResult() {
    var array = [];
    array = sessionStorage.getItem('answers');
    sessionStorage.removeItem('answers');
    return array;
}

function getQuestion() {
    var getRequest = new XMLHttpRequest();
    getRequest.open('GET', '/questions/get', true);
    getRequest.onload = function () {
        if (getRequest.status >= 200 && getRequest.status < 400) {
            var data = JSON.parse(getRequest.responseText);
            var label = document.getElementById("question");
            label.innerHTML = data.question;
            sessionStorage.actualQuestionId = data.id;
        }
    };
    getRequest.send(sessionStorage.actualQuestionId);
}

function writeResults(data) {
    var result = document.getElementById("results");
    result.innerHTML = data;
}






