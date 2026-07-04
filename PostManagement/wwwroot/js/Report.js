// ADD REPORT IN USER PAGE
function sendReport() {

    $.ajax({
        url: "/Report/AddReport",
        type: "POST",
        data: {
            type: $("#type").val(),
            reason: $("#reason").val(),
            postId: $("#postId").val()
        },
        success: function () {
            alert("Report sent");

            $("#reason").val("");
            $("#postId").val("");
        }
    });
}