using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Report_Project.Models;

public class MeetingScheduleController : Controller
{
    private readonly ReportDbContext _context;

    public MeetingScheduleController(ReportDbContext context)
    {
        _context = context;
    }

    // GET: Create Schedule
    public IActionResult Create()
    {
        return View();
    }

    // POST: Create Schedule
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Create(MeetingSchedule schedule)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        _context.MeetingSchedules.Add(schedule);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction("Index");
    //    }
    //    return View(schedule);
    //}

    [HttpPost]
    public IActionResult Create(MeetingSchedule meeting)
    {
        if (ModelState.IsValid)
        {
            // Save meeting schedule logic here
            return RedirectToAction("Index"); // Redirect after successful creation
        }

        // Return the view with errors if validation fails
        return View(meeting);
    }


    // List Scheduled Meetings
    public async Task<IActionResult> Index()
    {
        var schedules = await _context.MeetingSchedules.ToListAsync();
        return View(schedules);
    }
}
