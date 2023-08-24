using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseManager.Repo.Models;
using AutoMapper;
using CourseManager.Repo.Commons;
using CourseManager.Service.Interfaces;
using CourseManager.Service.ViewModels;

namespace CourseManager.Pages.Sessions
{
    public class IndexModel : PageModel
    {
        private readonly ISessionService _context;
        private readonly IMapper _mapper;

        public IndexModel(ISessionService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<SessionViewModel> Session { get; set; } = default!;
        public Pagination<SessionViewModel> Pagination { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public async Task OnGetAsync(int? index)
        {
            SearchString = (SearchString ?? "").Trim().ToLower();
            var pagination = await _context.GetByPage(x => x.StartTime.ToString().ToLower().Contains(SearchString), index ?? 0, 3,x=>x.Course,y=>y.Room);
            if (pagination != null)
            {
                Pagination = _mapper.Map<Pagination<SessionViewModel>>(pagination);
                Session = Pagination.Items.OrderBy(x => x.StartTime.ToString()).ToList();
            }

        }
    }
}
