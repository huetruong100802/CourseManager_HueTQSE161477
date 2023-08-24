﻿using System;
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

namespace CourseManager.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly ISubjectService _context;
        private readonly IMapper _mapper;

        public IndexModel(ISubjectService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<SubjectViewModel> Subject { get; set; } = default!;
        public Pagination<SubjectViewModel> Pagination { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public async Task OnGetAsync(int? index)
        {
            var pagination = await _context.GetByPage(index ?? 0, 3);
            if (pagination != null)
            {
                Pagination = _mapper.Map<Pagination<SubjectViewModel>>(pagination);
                Subject = Pagination.Items.OrderBy(x => x.Name).ToList();
                if (SearchString != null)
                {
                    SearchString = SearchString.Trim().ToLower();
                    Subject = Subject.Where(x => x.Name.ToLower().Contains(SearchString)).ToList();
                    Pagination.TotalItemsCount = Subject.Count;
                    Pagination.Items = Subject;
                }
            }

        }
    }
}
