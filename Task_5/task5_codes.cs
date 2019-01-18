### Views/Login.cshtml
<input type="button" class="login-button clockInOutBtn" value="Clock In" onclick="VerifyUserForClock()">
<input type="submit" class="login-button" value="Log In">

//serialized login form
function VerifyUserForClock() {
    /**
     * check both fields are filled in before submitting clockin/clockout form
     */
    var validForm = true;
    if ($.trim($("#UserName").val()) == "") {
        $("#username-error-msg").html("The Username/Email field is required.");   
        validForm = false;
    }
    if ($.trim($("#PassWord").val()) == "") {
        $("#password-error-msg").html("The Password field is required.");
        validForm = false;
    }
    if (!validForm) return;

    var login = $('#loginForm').serialize();

    $.post({
        url: "@Url.Action("VerifyUserForClock", "Account")",
        data: login,
        success: function (response) {
            
            if (response.verified == false) {
                $('#ErrorMessages').text("There was a problem with your credentials or account status. Please try again or contact your system administrator if the problem continues.").css("color", "red");

            } else  {

                $('#clock-modal').modal('show');
                $('#modal-note').text(response.EventNotes);
                $('#checkin-modal-title').text(response.userLastName + ", " + response.userFirstName);
            }
            
        },
        error: function () {
            alert('Fail');
        }
    })
}

/// Solution: Login.cshtml

<input type="submit" class="login-button clockInOutBtn" value="Clock In" onclick="VerifyUserForClock()" formaction="javascript:VerifyUserForClock()" formmethod="post" />
<input type="submit" class="login-button" value="Log In" />