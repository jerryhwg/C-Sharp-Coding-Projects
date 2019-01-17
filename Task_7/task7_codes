##### 1. Index.cshtml #####

///// Links for Approve or Deny Note function trigger /////

<a onclick='ApproveNote("@item.EventID")'>Approve</a> |
<a onclick='DenyNote("@item.EventID")'>Deny</a>


///// Approve or Deny function /////

jQuery (Ajax)

<script>
    //Loads modal for adding approve notes.
    function ApproveNote(EventId) {
        jQuery.ajax({
            'url': "@Url.Action("Approve", "TimeOffEvent")",
            'type': 'GET',
            'data': {
                id: EventId
            },
            'success': function (data) {
                document.getElementById("noteEditModalBody").innerHTML = data;
                $('#noteModal').modal('show');
            },
            error: function () {
                alert("An error Occurred.  Please try again or contact your system administrator.");
            }

        })
    };

    //Loads modal for adding deny notes.
    function DenyNote(EventId) {
        jQuery.ajax({
            'url': "@Url.Action("Deny", "TimeOffEvent")",
            'type': 'GET',
            'data': {
                id: EventId
            },
            'success': function (data) {
                document.getElementById("noteEditModalBody").innerHTML = data;
                $('#noteModal').modal('show');
            },
            error: function () {
                alert("An error Occurred.  Please try again or contact your system administrator.");
            }

        })
    };

</script>

@Scripts.Render("~/bundles/jqueryval")


///// Modal for Approve or Deny Note /////

<th>
    <div class="modal" id="noteModal" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h3>Approve Note</h3>
                </div>
                <div class="modal-body" id="noteEditModalBody">

                </div>
                <div class="modal-footer">
                    <button class="btn btn-primary" data-dismiss="modal">close</button>
                </div>
            </div>
        </div>
    </div>
</th>


##### 2. TimeOffEventController.cs #####

///// Action request from function to Controller to open Approve(Deny) Note modal /////

public ActionResult Approve(Guid id, string Note)
{
    return PartialView("_Approve");
}


##### 3. _Approve.cshtml #####

///// Approve Note (partial view) /////


@model ScheduleUsers.Models.WorkTimeEvent


@using (Html.BeginForm("Approve", "TimeOffEvent", FormMethod.Post))
{
    @Html.AntiForgeryToken()

    <div class="form-horizontal">

        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        @*Passes TimeOffEvent ID to the Approve Action*@
        @Html.HiddenFor(model => model.Id)

        <div class="form-group">
            @Html.LabelFor(model => model.Note, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Note, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Note, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>
}


##### 4. TimeOffEventController.cs #####

///// Process Approve(Deny) Note /////

[HttpPost, ActionName("Approve")]
[ValidateAntiForgeryToken]
public ActionResult ApproveNote(Guid id, string Note)
{
    var ApprovedEvent = db.TimeOffEvents.Find(id);
    ApplicationUser user = db.Users.Find(ApprovedEvent.User.Id);
    ApprovedEvent.ActiveSchedule = true;
    var approveID = User.Identity.GetUserId();
    ApprovedEvent.ApproverId = approveID;
    ApprovedEvent.Note = Note;

    Message m = new Message(ApprovedEvent, approveID, db); // Message constructor

    db.Messages.Add(m);
    db.SaveChanges();
    return RedirectToAction("Index");
}



##### 5. Message.cs #####

///// Message format /////

public virtual ApplicationUser Sender { get; set; } // Column header: Sender_Id
public virtual ApplicationUser Recipient { get; set; } // Coulmn header: Recipient_Id
public virtual TimeOffEvent TimeOffEventID { get; set; } //Column header: TimeOffEventID_TimeOffEventID

public Message(TimeOffEvent e, string s, ApplicationDbContext db) : this()
{

    Recipient = db.Users.Find(e.User.Id);
    TimeOffEventID = e;
    Sender = db.Users.Find(s);
    DateSent = DateTime.Now;
    string state = "";
    if (e.ActiveSchedule == true)
    {
        state = "approved";
    }
    else if (e.ActiveSchedule == false)
    {
        state = "denied";
    }
    MessageTitle = "Your time off request has been " + state + ".";
    Content = Sender.FirstName + " has " + state + " your time off request from " + e.Start + " to " + e.End + ". " + e.Note;
}


public Message()
{
    UnreadMessage = true;
    MessageID = Guid.NewGuid();
}