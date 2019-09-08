$(document).ready(function () {
    $("#btnTweet").click(function (e) {
        e.preventDefault();

        var text = document.getElementById('tweetText').value;

        if (text == '') {
            alert('Please fill all fields');
            return;
        }

        var token = $('[name=__RequestVerificationToken]').val();
        var tweetData = {
            text: text
        };
        tweetData['__RequestVerificationToken'] = token;

        $.ajax({
            url: "/Twitter/TweetUpdate",
            type: "POST",
            data: tweetData,
            success: function (response) {
                if (response.error) {
                    $("#success-msg").text("");
                    $("#error-msg").text(response.error);
                    return;
                }

                $("#error-msg").text("");
                $("#tweetLink").text("Your tweet is here");
                $("#tweetText").get(0).value = "";

                document.getElementById("tweetLink").href = response.url;
            },
            error: function (response) {
                alert('Error was occured, please try again later', response)
            }

        });

    });
});