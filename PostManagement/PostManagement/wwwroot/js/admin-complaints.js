$(document).ready(function () {
    loadComplaints();
});

function loadComplaints() {
    $.get("/Admin/ComplaintList", function (res) {
        drawTable(res);
    });
}

// DRAW
function drawTable(data) {

    let html = "";

    data.forEach(c => {

        html += `
        <tr>
            <td>${c.id}</td>
            <td>${c.postId}</td>
            <td>${ c.createdAt}</td>
            <td>${c.reason}</td>
            <td>${c.reporterName}</td>

            <td>
                <span class="badge ${c.isResolved ? 'bg-success' : 'bg-danger'}">
                    ${c.isResolved ? "Resolved" : "Pending"}
                </span>
            </td>

            <td>
                <button class="btn btn-sm btn-warning" onclick="editComplaint(${c.id})">Edit</button>
                <button class="btn btn-sm btn-danger" onclick="deleteComplaint(${c.id})">Delete</button>
                <button class="btn btn-sm btn-success" onclick="toggleStatus(${c.id})">Toggle</button>
            </td>
        </tr>`;
    });

    $("#complaintTable").html(html);
}

// ADD
function addComplaint() {

    $.ajax({
        url: "/Admin/AddComplaint",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({
            postId: $("#postId").val(),
            reason: $("#reason").val(),
            reporterName: $("#reporterName").val()
        }),
        success: function () {
            loadComplaints();
            clearForm();
        }
    });
}

// EDIT
function editComplaint(id) {

    $.get("/Admin/GetComplaint", { id: id }, function (c) {

        $("#postId").val(c.postId);
        $("#reason").val(c.reason);
        $("#reporterName").val(c.reporterName);

        $("#saveBtn").remove();

        $(".card:first").append(`
            <button id="saveBtn" class="btn btn-primary mt-2"
                onclick="updateComplaint(${c.id})">
                Update
            </button>
        `);
    });
}

// UPDATE
function updateComplaint(id) {

    $.ajax({
        url: "/Admin/UpdateComplaint",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({
            id: id,
            postId: $("#postId").val(),
            reason: $("#reason").val(),
            reporterName: $("#reporterName").val(),
            isResolved: false
        }),
        success: function () {
            loadComplaints();
            clearForm();
            $("#saveBtn").remove();
        }
    });
}

// DELETE
function deleteComplaint(id) {

    $.get("/Admin/DeleteComplaint", { id: id }, function () {
        loadComplaints();
    });
}

// STATUS TOGGLE
function toggleStatus(id) {

    $.post("/Admin/ToggleComplaintStatus", { id: id }, function () {
        loadComplaints();
    });
}

// SEARCH
function searchComplaint() {

    $.get("/Admin/SearchComplaint", {
        field: $("#searchField").val(),
        value: $("#searchValue").val()
    }, function (res) {
        drawTable(res);
    });
}

$(document).ready(function () {

    $("#searchValue").on("keyup", function (e) {
        if (e.key === "Enter") {
            searchComplaint();
        }
    });

});

// CLEAR
function clearForm() {
    $("#postId").val("");
    $("#reason").val("");
    $("#reporterName").val("");
}