var start = function startapplication() {
    postAnswer();
}();

function postAnswer() {
    var postRequest = new XMLHttpRequest();
    postRequest.open('POST', '/results/post', true);
    postRequest.setRequestHeader('Content-Type', 'application/json');
    postRequest.onreadystatechange = function(data) {

    }
    postRequest.send(JSON.stringify(sessionStorage.getItem('answers')));
}