$(document).ready(function () {
    $("#navbar").load("../HTML/navbar.html", function () {
        if(sessionStorage.getItem("Username") != null){
            document.getElementById("RegisterID").textContent = "Hello " + sessionStorage.getItem("Username");
            document.getElementById("RegisterID").href = "#";
            document.getElementById("LoginID").textContent = "Log off";
            document.getElementById("LoginID").onclick = LogOff;
            document.getElementById("LoginID").href = "menuPage.html";
        }
    });
});

function LogOff() {
    sessionStorage.removeItem("Username");
}