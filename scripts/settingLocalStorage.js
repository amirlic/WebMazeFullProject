window.onload = function def() {

    if (localStorage.length <= 2) {

        // Store
        localStorage.setItem("DefaultRows", 10);
        localStorage.setItem("DefaultCols", 10);

        // Retrieve
        document.getElementById("Rows").value = localStorage.getItem("DefaultRows");
        document.getElementById("Cols").value = localStorage.getItem("DefaultCols");
    }

    else {
        // Retrieve
        document.getElementById("Rows").value = localStorage.getItem("Rows");
        document.getElementById("Cols").value = localStorage.getItem("Cols");
    }
}

var btnSave = document.getElementById("save");

btnSave.onclick = function Save() {
    // Check browser support
        //var algo = $("#Algo").val();
        var rows = $("#Cols").val();
        var cols = $("#Rows").val();

        // Store
        localStorage.setItem("Rows", rows);
        localStorage.setItem("Cols", cols);
        //localStorage.setItem("Algo", algo);

        // Retrieve
        document.getElementById("Rows").value = localStorage.getItem("Rows");
        document.getElementById("Cols").value = localStorage.getItem("Cols");
        //document.getElementById("Algo").value = localStorage.getItem("Algo");
}