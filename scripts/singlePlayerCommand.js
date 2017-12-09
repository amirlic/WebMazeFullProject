var btnSingle = document.getElementById("start");

btnSingle.onclick = function getMaze() {

    var apiUrl = "../api/maze";
    // Send an AJAX request
    var maze = {
        Name: $("#Name").val(),
        Rows: $("#Rows").val(),
        Cols: $("#Cols").val()
    };

    var name = $("#Name").val();
    document.title = name;

    $("#loadingGif").show();

    //$.getJSON(apiUrl,game).done(function (maze) {
    //    alert(maze.Name);
    //});

    $.post(apiUrl, maze).done(function (data) {
        var items = [];

        if (data != null) {

            obj = JSON.parse(data);

            var Name = obj.Name;
        }
    });
}