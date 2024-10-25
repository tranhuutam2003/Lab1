using Microsoft.AspNetCore.Mvc;
using Lab1.Data;
using Lab1.Models;

namespace Lab1.ViewComponents
{
    public class MajorViewComponent:ViewComponent
    {
        SchoolContext db;
        List<Major> majors;

        public MajorViewComponent(SchoolContext _context)
        {
            db= _context;  
            majors = db.Majors.ToList();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderMajor",majors);
        }
    }
}
