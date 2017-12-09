document.getElementById("Login").onclick = function sub() {
    
    var apiUrl = "../api/Users";
    // Send an AJAX request
    var name = $("#User").val();
    var pass = $("#Pass").val();


    $.get(apiUrl + "/" + name + "/" + pass).done(function (data) {

        if (data != null) {

            alert(data);
            if (data == "Success") {
                sessionStorage.setItem("Username", name);
                window.location.href = "./menuPage.html";
            }
            else {
                alert("Plaese Register First");
            }
        }
    });
}