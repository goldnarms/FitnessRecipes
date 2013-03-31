(function () {
    $(document).ready(function () {
        var btnSearchDiet, btnAddComment, dietId, message, name, weburl, email, commentid, userid;
        btnSearchDiet = $("#btnSearchDiet");
        btnAddComment = $("#btnAddComment");
        dietId = $("#hiDietId");
        message = $("#tbMessage");
        name = $("#tbName");
        weburl = $("#tbWebsite");
        email = $("#tbEmail");
        commentid = $("#hiCommentId");
        userid = 0;
        $(".btnReply").bind("click", function () {
            $("#hiCommentId").val($(this).data("commentid"));
        });
        btnSearchDiet.bind("click", function (e) {
            $("#searchResult").load("/diet/SearchResult?searchString=" + $("#tbSearchField").val());
        });
        btnAddComment.bind("click", function () {
            $("#comments").load("/diet/AddNewComment?dietId=" + dietId.val() + "&message=" + message.val() + "&name=" + name.val() + "&webUrl=" + weburl.val() + "&email=" + email.val() + "&commentId=" + commentid.val() + "&userId=" + userid, function () {
                $("#hiCommentId").val("0");
            });
        });
        $("#btnSetAsDefault").bind("click", function () {
            $.post("/diet/SetDietAsDefault?dietId=" + dietId.val());
        });
    });
}).call(this);
