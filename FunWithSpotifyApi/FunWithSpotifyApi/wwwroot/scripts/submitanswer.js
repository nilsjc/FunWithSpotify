var start = function startapplication() {
    if (typeof (Storage) == "undefined") {
        alert("No session storage. You cannot use this application.");
        return;
    }
    var a = [];
    a.push(JSON.parse(localStorage.getItem('answers')));
    localStorage.setItem('answers', JSON.stringify(a));
    sessionStorage.actualQuestionId = 0;
    getQuestion();
}();

function selectAnswer(selectedValue) {
    //Create object to send
    var result = {
        id: sessionStorage.actualQuestionId,
        value: selectedValue
    }
    saveDataToLocalStorage(result);
    postAnswer(result);
}

function postAnswer(result) {
    var postRequest = new XMLHttpRequest();
    postRequest.open('POST', '/questions/post', true);
    postRequest.setRequestHeader('Content-Type', 'application/json');
    postRequest.send(JSON.stringify(result));
    //Get new question from server
    getQuestion();
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
    getRequest.send();
}

function saveDataToLocalStorage(data) {
    var array = [];
    array = JSON.parse(localStorage.getItem('answers'));
    array.push(data);
    if (array.length > 6)
        // send to server for evaluation
    localStorage.setItem('answers', JSON.stringify(array));
}



