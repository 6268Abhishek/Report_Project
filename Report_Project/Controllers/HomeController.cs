using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Report_Project.Models;
using System.Diagnostics;

namespace Report_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ReportDbContext _context;

        public HomeController(ILogger<HomeController> logger,ReportDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index()
		{
            var reports =await _context.reports.ToListAsync();
            return View(reports);

		}
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var report = await _context.reports.FindAsync(id);
            if (report == null) return NotFound();

            return View(report);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Report report)
        {
            if (id != report.Report_id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.Report_id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        public IActionResult Delete()
        {
            return View();
        }
       

        public IActionResult Details(int id)
        {
            var report = _context.reports.FirstOrDefault(r => r.Report_id == id);
            if (report == null) return NotFound();
            return View(report);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
