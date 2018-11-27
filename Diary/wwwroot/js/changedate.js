function sendRequest(){

    var form = document.getElementById("formAjaxEx");

    var formData = new FormData(form);

    var request = new XMLHttpRequest();

    request.open("POST", form.action);
    document.getElementById("output").innerHTML = "<img style='max-width: 100%;' src=\"images/bb_cat_dribbble.gif\" alt=\"Loading...\"></img>";
    request.onreadystatechange = function () {
        if (request.readyState == 4 && request.status == 200)
            document.getElementById("output").innerHTML=request.responseText;
    }
    request.send(formData);
}