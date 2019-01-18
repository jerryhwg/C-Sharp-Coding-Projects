### Color is correct, the word shows the Clock Out instead of Clock In (see task6_img.png)

/// After enter an user name ->
"Network" tab in Chrome debug console
CheckForUserData action
public JsonResult CheckForUserData(string userdata) action

/// Check if the user is currently clocked in
bool ClockedIn = db.WorkTimeEvents.Where(x => x.Id == user.Id && !x.End.HasValue).Any();
return Json(new WorkTimeEventCreateViewModel(true, ClockedIn, newMessages, currentWorkTimeEvents), JsonRequestBehavior.AllowGet);

ClockedIn = false or true
Button color works
Button text does not work consistently

/// "Element" tab in Chrome debug console

<input type="submit" class="login-button clockInOutBtn" value="Clock Out" onclick="VerifyUserForClock()" formaction="javascript:VerifyUserForClock()" formmethod="post">

vs in code
<input type="submit" class=" login-button clockInOutBtn" value="Clock In" formaction=@Url.Action("Create", "WorkTimeEvent") formmethod="post" />

/// Traced to Login.cshtml
if (data.ClockedIn == true) {
    $(".clockInOutBtn").prop('disabled', false).val('Clock Out').addClass("clockoutbutton");

else {
    $(".clockInOutBtn").prop('disabled', false).html('Clock In').removeClass("clockoutbutton");

/// Corrected codes in Login.cshtml

if (data.ClockedIn == true) {
	$(".clockInOutBtn").prop('disabled', false).val('Clock Out').addClass("clockoutbutton");

}
else {
	$(".clockInOutBtn").prop('disabled', false).val('Clock In').removeClass("clockoutbutton");

/// A complete code section

function UserCheck() {
    $.post("@Url.Action("CheckForUserData", "Account")",
        {
            userdata: $("#UserName").val()
        },
        function (data) {
            if (data.UserVerified == true) {
                $("#UserName").css("border-color", "Green");
                $("#currentWorkTimeEventHours").html(data.ClockInOut);
                $("#newMessagesNotification").html(data.NewMessagesNotification);
                if (data.ClockedIn == true) {
                    $(".clockInOutBtn").prop('disabled', false).val('Clock Out').addClass("clockoutbutton");

                }
                else {
                    $(".clockInOutBtn").prop('disabled', false).val('Clock In').removeClass("clockoutbutton");
                }
            }
            else {
                $(".clockInOutBtn").prop('disabled', true).val('Clock In').removeClass("clockoutbutton");
                $("#UserName").css("border-color", "Red");
                $("#currentWorkTimeEventHours").html("");
                $("#newMessagesNotification").html("");
            }
        }

    );
}