using Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        private List<MenuItem> MenuItems = new List<MenuItem>();
        public RenderViewComponent()
        {
            MenuItems = new List<MenuItem>() {
                new MenuItem(){Id = 1, Name = "Branches", Link="Branches/List"},
                new MenuItem(){Id = 2, Name = "Student", Link="Admin/Student/List" },
                new MenuItem(){Id = 3, Name = "Subject", Link="Subject/List" },
                new MenuItem(){Id = 4, Name = "Coures", Link="Coures/List" }
            };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderLeftMenu", MenuItems);
        }


    }
}
