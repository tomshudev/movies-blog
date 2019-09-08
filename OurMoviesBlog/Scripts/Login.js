$(document).ready(function () {
    $("#btnLogin").click(function (e) {
        e.preventDefault();

        var username = document.getElementById('username').value;
        var password = document.getElementById('password').value;

        if (username == '' || password == '') {
            alert('Please fill all fields');
            return;
        }

        var token = $('[name=__RequestVerificationToken]').val();
        var userData = {
            username: username,
            password: password
        };
        userData['__RequestVerificationToken'] = token;

        $.ajax({
            url: "/Admin/Login",
            type: "POST",
            data: userData,
            success: function (response) {
                if (response.error) {
                    $("#success-msg").text("")
                    $("#error-msg").text(response.error)
                    return;
                }

                $("#error-msg").text("")
                $("#success-msg").text("You have been logged in, redirecting")

                setTimeout(function () {
                    window.location.href = "/"
                }, 1200)

                //window.location.reload();
            },
            error: function (response) {
                alert('Error was occured, please try again later', response)
            }

        });

    });
});