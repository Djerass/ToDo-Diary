var request = new XMLHttpRequest();
request.open("GET", "/Exercise/ListofEx");
document.getElementById("output").innerHTML = "<img src=\"images/bb_cat_dribbble.gif\" alt=\"Loading...\"></img>";
request.onreadystatechange = function () {
    if (request.readyState == 4 && request.status == 200)
        document.getElementById("output").innerHTML = request.responseText;
}
request.send();