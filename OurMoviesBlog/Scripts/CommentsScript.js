$(document).ready(function () {
    $("#addComment").click(function (e) {
        e.preventDefault();

        var title = document.getElementById('title').value;
        var authorName = document.getElementById('authorName').value;
        var content = document.getElementById('content').value;
        var postId = document.getElementById('postId').outerText;

        if (title == '' || authorName == '' || content == '') {
            alert('fill all fields');
            return;
        }

        var token = $('[name=__RequestVerificationToken]').val();
        var commentData = {
            PostID: postId,
            Title: title,
            AuthorName: authorName,
            Content: content
    };
    commentData['__RequestVerificationToken'] = token;

    $.ajax({
        url: "/Comments/Add",
        type: "POST",
        data: commentData,
        success: function (response) {
            console.log(response);
            if (response.succeeded) {
                var commentData = response.commentData;
                var tblRow = `
                            <li class="blog-comment">
                                <p class="meta"><strong>` + commentData.AuthorName + `</strong></p>
                                <p>
                                    <strong>` + commentData.Title + `</strong>
                                    <br />` + commentData.Content + `
                                </p>
                            </li>`
                $("#comment-list").append(tblRow);

                // clear the fields
                document.getElementById('title').value = ''
                document.getElementById('authorName').value = ''
                document.getElementById('content').value = ''

            }
            //window.location.reload();
        },
        error: function (response) {
            alert('Error was occured, please try again later')
        }

    });

});
    });