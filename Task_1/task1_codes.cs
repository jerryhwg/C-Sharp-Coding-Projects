### Views/Account/Login.cshtml

@Html.TextBoxFor(m => m.Email, new { @class = "form-control text-center centerthis", placeholder = "username", onchange = "focus(), blur(), UserCheck()", onselect = "UserCheck()", id = "UserName" })

javascript
function UserCheck()
$.post("@Url.Action("CheckForUserData", "Account")",
{
     userdata: $("#UserName").val()
}


##### Solution #####

Key:
var user = db.Users.Where(x => x.UserName == userdata || x.Email == userdata).SingleOrDefault();


### AccountController.cs

[AllowAnonymous]
public JsonResult CheckForUserData(string userdata) // userdata comes from function UserCheck() on Login.cshtml
{

//Finds the user with the email provided in the username input
var user = db.Users.Where(x => x.UserName == userdata || x.Email == userdata).SingleOrDefault();

//if the user exists
if (user != null)
{
    bool newMessages = db.Messages.Where(m => m.Recipient.Id == user.Id).Where(n => n.UnreadMessage == true).Any();// does the user have any messages
    //Find any events that started or ended today
    var currentWorkTimeEvents = db.WorkTimeEvents.Where(u => u.Id == user.Id).
                                                 Where(e =>  DbFunctions.TruncateTime(e.Start) == DateTime.Today.Date||
                                                             DbFunctions.TruncateTime(e.End) == DateTime.Today.Date)
                                                             .OrderBy(x => x.Start).ToList();
    //If there aren't any events from today, check if there any events still open by checking if they don't have an end
    
    if (currentWorkTimeEvents.Count == 0)
    {
        currentWorkTimeEvents = db.WorkTimeEvents.Where(u => u.Id == user.Id).Where(e => e.End == null).OrderBy(x => x.Start).ToList();  
       
    }


    //Check if the user is currently clocked in
    bool ClockedIn = db.WorkTimeEvents.Where(x => x.Id == user.Id && !x.End.HasValue).Any();
    return Json(new WorkTimeEventCreateViewModel(true, ClockedIn, newMessages, currentWorkTimeEvents), JsonRequestBehavior.AllowGet);

}
//The user doesn't exist
else
{
    return Json(new WorkTimeEventCreateViewModel(), JsonRequestBehavior.AllowGet);
}

}