$(document).ready(function () {
    LoadPosts();
});

// LIST
function LoadPosts() {

    $.ajax({
        url: '/Post/PostList',
        type: 'GET',
        success: function (res) {

            var html = '';

            $.each(res, function (i, item) {

                html += `
                <div class="col-md-4 mb-4">
                    <div class="card post-card shadow-sm border-0 rounded-4 overflow-hidden">

                        <img src="${item.imageUrl}" class="post-img"/>

                        <div class="card-body">

                            <div class="d-flex justify-content-between">
                                <b>@${item.authorName}</b>
                                <small class="text-muted">${item.tag}</small>
                            </div>

                            <h6 class="mt-2">${item.title}</h6>
                           <button class="btn btn-outline-danger btn-sm mt-2"
        onclick="reportPost(${item.id})">
    🚨 Report
</button>

                            <small class="text-secondary">
                                ${new Date(item.createdAt).toLocaleString()}
                            </small>

                        </div>
                    </div>
                </div>`;
            });

            $('#post_container').html(html);
        }
    });
}

// ADD MODAL
$('#btnAddPost').click(function () {
    Clear();
    $('#PostModal').modal('show');
});

// ADD
function AddPost() {

    var obj = {
        Title: $('#Title').val(),
        Content: $('#Content').val(),
        ImageUrl: $('#ImageUrl').val(),
        Tag: $('#Tag').val(),
        AuthorName: $('#AuthorName').val()
    };

    $.ajax({
        url: '/Post/AddPost',
        type: 'POST',
        data: obj,
        success: function () {
            $('#PostModal').modal('hide');
            LoadPosts();
        }
    });
}

// CLEAR
function Clear() {
    $('#Title').val('');
    $('#Content').val('');
    $('#ImageUrl').val('');
    $('#Tag').val('');
    $('#AuthorName').val('');
}

$('#searchInput').on('keyup', function () {

    var value = $(this).val();

    if (value.length === 0) {
        LoadPosts();
        return;
    }

    $.ajax({
        url: '/Post/Search',
        type: 'GET',
        data: { keyword: value },
        success: function (res) {

            var html = '';

            $.each(res, function (i, item) {

                html += `
                <div class="col-md-4 mb-4">
                    <div class="card post-card shadow-sm">

                        <img src="${item.imageUrl}" class="post-img"/>

                        <div class="card-body">

                            <div class="d-flex justify-content-between">
                                <b>@${item.authorName}</b>
                                <small class="text-muted">${item.tag}</small>
                            </div>

                            <h6 class="mt-2">${item.title}</h6>
                            <p>${item.content}</p>

                            <button class="btn btn-outline-danger btn-sm mt-2"
        onclick="reportPost(${item.id})">
    🚨 Report
</button>

                        </div>
                    </div>
                </div>`;
            });

            $('#post_container').html(html);
        }
    });
});
function reportPost(postId) {

    let reason = prompt("Report reason:");

    if (!reason || reason.trim() === "")
        return;

    $.ajax({
        url: "/Post/ReportPost",
        type: "POST",
        data: {
            postId: postId,
            reason: reason
        },
        success: function () {
            alert("Report submitted successfully.");
        }
    });
}