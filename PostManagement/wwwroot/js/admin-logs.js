$(document).ready(function () {
    loadLogs();
});

let editId = 0;

// LOAD
function loadLogs() {
    $.get("/Admin/LogList", function (res) {
        drawTable(res);
    });
}

// DRAW
function drawTable(data) {

    let html = "";

    data.forEach(x => {

        html += `
        <tr>
            <td>${x.id}</td>

            <td>
                ${x.createdAt
                ? new Date(x.createdAt).toLocaleString("tr-TR")
                : "-"}
            </td>

            <td>${x.action}</td>
            <td>${x.detail}</td>

            <td>
                <button class="btn btn-warning btn-sm" onclick="editLog(${x.id})">Edit</button>
                <button class="btn btn-danger btn-sm" onclick="deleteLog(${x.id})">Delete</button>
            </td>
        </tr>`;
    });

    $("#logTable").html(html);
}

// ADD
function addLog() {

    let model = {
        action: $("#action").val(),
        detail: $("#detail").val()
    };

    $.ajax({
        url: "/Admin/AddLog",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(model),
        success: function () {
            loadLogs();
            clearForm();
        }
    });
}

// EDIT
function editLog(id) {

    $.get("/Admin/GetLog", { id: id }, function (res) {

        editId = res.id;

        $("#action").val(res.action);
        $("#detail").val(res.detail);

        $("#saveBtn").remove();

        $(".row.mb-3").first().append(`
            <button id="saveBtn" class="btn btn-primary mt-2"
                onclick="updateLog()">
                Update
            </button>
        `);
    });
}

// UPDATE
function updateLog() {

    let model = {
        id: editId,
        action: $("#action").val(),
        detail: $("#detail").val()
    };

    $.ajax({
        url: "/Admin/UpdateLog",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(model),
        success: function () {
            loadLogs();
            clearForm();
            $("#saveBtn").remove();
            editId = 0;
        }
    });
}

// DELETE
function deleteLog(id) {

    $.get("/Admin/DeleteLog", { id: id }, function () {
        loadLogs();
    });
}

// SEARCH
function searchLog() {

    $.get("/Admin/SearchLog", {
        field: $("#searchField").val(),
        value: $("#searchText").val()
    }, function (res) {
        drawTable(res);

        $("#searchText").val("");
    });
}

$(document).ready(function () {

    $("#searchText").on("keyup", function (e) {
        if (e.key === "Enter") {
            searchLog();
        }
    });

});

// CLEAR
function clearForm() {
    $("#action").val("");
    $("#detail").val("");
}