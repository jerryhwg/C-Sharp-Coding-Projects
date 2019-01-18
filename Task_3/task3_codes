### Steps and Codes

Admin (adam) login -> Calendar (Schedule) -> Create New -> Select an Employee 
=> Edit Shift Templates -> Edit or Create or Delete -> Create Shift (save change)
Then
Schedule Creator page - Shift Template column does not reflect it immediately until you reload the web page

Work target:
Create/Edit/Delete

===>

http://localhost:59611/Employer/Schedule/Create
Areas -> Employer -> Controllers -> ScheduleController.cs -> Method "Create"

Areas -> Views -> Schedule -> Create.cshtml - Edit Shift Templates
<script>
/** ajax submit for Create New shift template **/
 $.post({
url: "@Url.Action("Create", "Shift")"
// if content = SHIFTMODAL, then create new shift was success, and need to re-load "_ModalShifts" with new shifts dropdown
if (content == "<!--SHIFTMODAL-->") {
   $('#shift-modal-dropdown').html(data.substring(17));
   // clear shift-details with success message
   $('#shift-details').html('New Shift Template created!');
}

id=shift-modal-dropdown
<div class="col-sm-5" id="shift-modal-dropdown">
	@*Dropdown for shift selection*@
	@{
		Html.RenderAction("ShiftModal", "Shift");
	}
</div>

Create Shift button =>
Request URL: http://localhost:59611/Employer/Shift/ShiftModal
Areas -> Employer -> ShiftController.cs -> 
//GET: Create/CreateScheduleForUser
public ActionResult ShiftModal()
List<SelectListItem> shifts = new List<SelectListItem>();
return PartialView("_ModalShifts", shifts);

Areas/Employer/Views/Shared/_ModalShifts.cshtml



 // GET: Employer/Shift/Create
public ActionResult Create(string Id)
return View();

[HttpPost]
public ActionResult Create([Bind(Include = "Id,StartTime,EndTime")] ScheduleShiftTemplate shift)
return RedirectToAction("ShiftModal");
return PartialView(shift);


cf. Reload loads the new shift template
_scheduleShiftsTable.cshtml

<th class="shift-row shift-row-header">Shift Template</th>
foreach (var WorkPeriod in Model.WorkPeriods)
@Html.Partial("_scheduleShiftRow", WorkPeriod, new ViewDataDictionary(ViewData)

// So I assume it's directly loaded from database after a new shift template is saved to the database


ref. function loadUserNewSchedule(userId)

ajax -> controller get view -> return to ajax -> add returned content to page

ajax : go get it
$.get (
url:
success:
get ElementByID.innerHTML = Dropdown


const NewScheduleForUser = '@Url.Action("createNewScheduleForUser", "Schedule")';

public ActionResult createNewScheduleForUser(string Id)

=>

return PartialView("_scheduleShiftsTable", scheduleVM);

=>

_scheduleShiftsTable.cshtml



<table id="shift-row-container" class="table">
<tr>
	<th class="shift-row shift-row-header">Start Day</th>
	<th class="shift-row shift-row-header">Shift Template</th>
	<th class="shift-row shift-row-header">Day Off</th>
	<th class="shift-row shift-row-header">Start Time</th>
	<th class="shift-row shift-row-header">End Time</th>
</tr>
@{
	int shiftcount = 0;
	int dayofweek = 0;

	foreach (var WorkPeriod in Model.WorkPeriods)
	{
		@Html.Partial("_scheduleShiftRow", WorkPeriod, new ViewDataDictionary(ViewData)
							 {
								{ "shiftcount", shiftcount },
								{ "dayofweek", dayofweek }
							 });

		shiftcount++;
		dayofweek++;
		@* loop through each day for each shift, if end of week, then reset week *@
		if (dayofweek > 6) { dayofweek = 0; }
	}
}
</table>

_scheduleShiftRow.cshtml

Shift Template part
<td>
<select id="shift-template-@shiftcount" name="shifttemplate" class="form-control shift-template">
	@foreach (var st in shifttemplates)
	{
		@* If shift Id is (id 1), then display blank*@
		if (st.Id == "1")
		{
			<option value="@st.Id">-</option>
		}
		@* Else show shift template row*@
		else
		{
			var st_start = st.StartTime.Value.ToString("h:mm tt");
			var st_end = st.EndTime.Value.ToString("h:mm tt");
			<option value="@st_start|@st_end">@st_start - @st_end</option>
		}
	}
</select>
</td>


##### Code Solution #####

Create  a new method to feed the port of table rows from database and let the ajax call the method and update the table rows specifically.

$.ajax({
    type: "GET",
    url: "@Url.Action("DropDownAction", "Schedule")",
    success: function(response) {
        $('.shift-template').html(response);
    },
    error:function(){
    alert("Error!");
    }
});


### ScheduleController.cs

public ActionResult DropDownAction(){
    ViewData["shifttemplates"] = GetShiftTemplates();
    return PartialView("_dropdownlist");
}

/// <summary>
/// Id is schedule template Id
/// </summary>
/// <param name="Id"></param>
/// <returns></returns>

public PartialViewResult getScheduleTemplateShifts(string Id)
{
    return PartialView("_scheduleShiftsTable");
}


### _dropdownlist.cshtml (partial view)

@model ScheduleUsers.Models.ScheduledWorkPeriod

@{
    var shiftcount = Convert.ToInt32(ViewData["shiftcount"]);
    var shifttemplates = ViewData["shifttemplates"] as List<ScheduleUsers.Models.ScheduleShiftTemplate>;
}

<select id="shift-template-@shiftcount" name="shifttemplate" class="form-control shift-template">
    @foreach (var st in shifttemplates)
    {
        @* If shift Id is (id 1), then display blank*@
        if (st.Id == "1")
        {
            <option value="@st.Id">-</option>
        }
        @* Else show shift template row*@
        else
        {
            var st_start = st.StartTime.Value.ToString("h:mm tt");
            var st_end = st.EndTime.Value.ToString("h:mm tt");
            <option value="@st_start|@st_end">@st_start - @st_end</option>
        }
    }
</select>