$(document).ready(function () {
    loadPosts();
});

// LOAD
function loadPosts() {
    $.get("/Admin/PostList", function (res) {
        drawTable(res);
    });
}

// ADD
function addPost() {

    $.ajax({
        url: "/Admin/AddPost",
        type: "POST",
        data: {
            Title: $("#title").val(),
            Content: $("#postContent").val(),
            ImageUrl: $("#imageUrl").val(),
            Tag: $("#tag").val(),
            AuthorName: $("#authorName").val()
        },
        success: function () {
            loadPosts();
            clearForm();
        }
    });
}

// EDIT
function editPost(id) {

    $.get("/Admin/GetPost", { id: id }, function (p) {

        $("#title").val(p.title);
        $("#postContent").val(p.content);
        $("#imageUrl").val(p.imageUrl);
        $("#tag").val(p.tag);
        $("#authorName").val(p.authorName);

        $("#saveBtn").remove();

        $(".card:first").append(`
            <button id="saveBtn" class="btn btn-primary mt-2"
                onclick="updatePost(${p.id})">
                Update
            </button>
        `);
    });
}

// UPDATE
function updatePost(id) {

    $.ajax({
        url: "/Admin/UpdatePost",
        type: "POST",
        data: {
            Id: id,
            Title: $("#title").val(),
            Content: $("#postContent").val(),
            ImageUrl: $("#imageUrl").val(),
            Tag: $("#tag").val(),
            AuthorName: $("#authorName").val()
        },
        success: function () {
            loadPosts();
            clearForm();
            $("#saveBtn").remove();
        }
    });
}

// DELETE
function deletePost(id) {
    $.get("/Admin/DeletePost", { id: id }, function () {
        loadPosts();
    });
}

// SEARCH
function searchPost() {

    $.ajax({
        url: "/Admin/SearchPost",
        type: "GET",
        data: {
            field: $("#searchField").val(),
            value: $("#searchValue").val()
        },
        success: function (res) {
            drawTable(res);

            $("#searchValue").val("");
        }
    });
}

$(document).ready(function () {

    $("#searchValue").on("keyup", function (e) {
        if (e.key === "Enter") {
            searchPost();
        }
    });

});

// TABLE
function drawTable(data) {

    let html = "";

    data.forEach(p => {

        html += `
        <tr>
            <td>${p.id}</td>
            <td>
                <img src="${p.imageUrl}" style="width:60px;height:60px;object-fit:cover;border-radius:8px;">
            </td>
            <td>${p.title}</td>
            <td>${p.content}</td>
            <td>${p.authorName}</td>
            <td>${p.tag}</td>
            <td>${new Date(p.createdAt).toLocaleString()}</td>
            <td>
                <button class="btn btn-warning btn-sm" onclick="editPost(${p.id})">Edit</button>
                <button class="btn btn-danger btn-sm" onclick="deletePost(${p.id})">Delete</button>
            </td>
        </tr>`;
    });

    $("#postTable").html(html);
}

// CLEAR
function clearForm() {
    $("#title").val("");
    $("#postContent").val("");
    $("#imageUrl").val("");
    $("#tag").val("");
    $("#authorName").val("");
}