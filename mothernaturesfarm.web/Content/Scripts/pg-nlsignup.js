(function () {

    function newsletterSignup(email) {
        $.ajax({
            type: "POST",
            url: "/Home/NewsletterSignup",
            data: { "email": email },
            success: function (res) {                
                if (res === 0) {
                    $("#nlSignupForm").hide();
                    $("#nlSignupMessage")
                        .html(
                            "<h3>Thanks for signing up!</h3><p>Be on the lookout for great offers from the farm!</p>")
                        .fadeIn();
                } else {
                    $("#nlSignupForm").hide();
                    $("#nlSignupMessage")
                        .html(
                            "<h3>Oops!</h3><p>We sorry but we could not sign you up for our newsletter at this time, please try again later.</p>").fadeIn();
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $("#nlSignupForm").hide();
                $("#nlSignupMessage")
                    .html(
                        "<h3>Oops!</h3><p>We sorry but we could not sign you up for our newsletter at this time, please try again later.</p>").fadeIn();
            }
        });            
    }

    $(document).ready(function() {
        $("#btnNLSignup").on("click", function () {
            var email = $("#fieldEmail").val();
            newsletterSignup(email);
        });
    });
})();