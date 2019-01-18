### Codes

ScheduleUsers > Models > Shift.cs > ScheduleShiftTemplate

namespace ScheduleUsers.Models
{
    public class Shift
    {
        public string Id { get; set; }

        // time picker for start time input
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime? StartTime { get; set; }

        // time picker for end time input
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public DateTime? EndTime { get; set; }
    }

    /// <summary>
    /// This class inherits the Shift class and contains the pre-defined "Shift templates" that can be applied to
    /// user schedules. These shift templates can be edited on the Schedule/Create page.
    /// These shift templates only require an Id, StartTime and EndTime
    /// </summary>
    public class ScheduleShiftTemplate : Shift
    {

        public ScheduleShiftTemplate()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

/// Solution Points

Original
[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:h:mm tt}")]
[DataType(DataType.DateTime)]
[Display(Name = "Start Time")]
public DateTime? StartTime { get; set; }

Update
[DataType(DataType.Time)]
[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
[Display(Name = "Start Time")]
public DateTime? StartTime { get; set; }
