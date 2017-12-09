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