function updateMoviesRate() {
    $(function () {
        var moviesTitles = $(".card-body-heading").children();
        var imdbVotes = $(".imdbVoters");
        var imdbRate = $(".imdbRating");

        for (var i = 0; i < moviesTitles.length; i++) {
            getRatingFromIMDB(i, moviesTitles, imdbRate,  imdbVotes);
        }
    });

}

function getRatingFromIMDB(i, moviesTitles, imdbRate, imdbVotes) {
    $.ajax({
        url: "http://www.omdbapi.com/",
        async: false,
        type: "GET",
        data: { "t": moviesTitles[i].text, "apikey": "77e467a1" },
        success: function (response) {
            if (response.error) {
                return;
            }

            if (isNaN(response.imdbRating)) {
                imdbRate[i].outerText = "rating is unavaliable";
            } else {
                imdbRate[i].outerText = response.imdbRating;
                imdbVotes[i].outerText = "out of " + response.imdbVotes + " voters";
            }
        },
        error: function (response) {
            alert('Error was occured, please try again later', response)
        }
    });
}