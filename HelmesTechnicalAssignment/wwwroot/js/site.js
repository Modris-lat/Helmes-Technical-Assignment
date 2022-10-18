function getData() {
    var input = document.getElementById("inputText").value;

    window.location = window.location.origin + "?command=GetData&input=" + input;
}
