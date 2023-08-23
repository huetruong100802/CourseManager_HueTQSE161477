using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseManager.Repo.Models;

namespace CourseManager.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly CourseManager.Repo.Models.CourseManagerDBContext _context;

        public IndexModel(CourseManager.Repo.Models.CourseManagerDBContext context)
        {
            _context = context;
        }

        public IList<Subject> Subject { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subjects != null)
            {
                Subject = await _context.Subjects
                .Include(s => s.Major).ToListAsync();
            }
        }
    }
}
