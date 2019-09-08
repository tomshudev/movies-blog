$(document).ready(function () {
    var token = $('[name=__RequestVerificationToken]').val();
    var bodyData = {
        movieId: "@Model.Movie.MovieID",
        currentPostId: "@Model.PostID"
    };
    bodyData['__RequestVerificationToken'] = token;
    $.ajax({
        url: "/Posts/WantMore",
        type: "Post",
        data: bodyData,
        success: function (response) {
            var el = document.getElementById("morePosts");

            if (!response.error) {
                el.href = response.url;
            }
            else {
                el.parentElement.removeChild(el);
            }
        },
        error: function (res) {
            console.log('err', res)
        }
    });

});