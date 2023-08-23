using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourseManager.Repo.Models;

namespace CourseManager.Pages.Sessions
{
    public class CreateModel : PageModel
    {
        private readonly CourseManager.Repo.Models.CourseManagerDBContext _context;

        public CreateModel(CourseManager.Repo.Models.CourseManagerDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
        ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Session Session { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sessions == null || Session == null)
            {
                return Page();
            }

            _context.Sessions.Add(Session);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
