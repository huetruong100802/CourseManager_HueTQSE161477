using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourseManager.Repo.Models;

namespace CourseManager.Pages.Students
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
        ViewData["MajorId"] = new SelectList(_context.Majors, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Students == null || Student == null)
            {
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
