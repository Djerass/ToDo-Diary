function  check() {
    var form = document.getElementById("formAjaxAdd");
    var items = document.getElementById("listOfex").getElementsByTagName("option");
    var inp = form.querySelector("#input0");
    var flag = false;
    for (var i in items) {
        if (items[i].value == inp.value) {
            flag = true;
            break;
        }
    }
    return flag;
}
function SendAddRequest(){
    

    var form = document.getElementById("formAjaxAdd");
    var inp = form.querySelector("#input1");
    var inp2 =form.querySelector("#input2");
    if (check() !== false) {
        let res1 = inp.value.indexOf(",");
        if (inp2.value.length == 0) {
            document.getElementById("input2val").innerHTML = "Pls insert count";
            inp2.style = "border: 1px  solid red";
            return;
        }
        console.log("точка на " + res);
        if (res1 != -1) {
            inp.value = inp.value.replace(",", ".");
        }
        if (inp.value.length == 0) {
            document.getElementById("input1val").innerHTML = "Pls insert Weight";
            inp.style = "border: 1px  solid red";
            return;
        }
        if (isNaN(inp.value)) {
            document.getElementById("input1val").innerHTML = "Pls insert Weight";
        }
        else {
            var res = inp.value.indexOf(".");
            console.log("точка на " + res);
            if (res != -1) {
                inp.value = inp.value.replace(".", ",");
            }
            console.log(inp.value);
            var formData = new FormData(form);
            var request = new XMLHttpRequest();
            request.open("POST", form.action);
            document.getElementById("output").innerHTML = "<h3>Loading...</h3>";
            request.onreadystatechange = function () {
                if (request.readyState == 4 && request.status == 200)
                    document.getElementById("output").innerHTML = request.responseText;
            }
            request.send(formData);
        }
    } else {
        var inp0 = form.querySelector("#input0");
        inp0.style = "border: 1px  solid red";
        document.getElementById("input0val").innerHTML = "Pls choose from list";
        return;

    }
}