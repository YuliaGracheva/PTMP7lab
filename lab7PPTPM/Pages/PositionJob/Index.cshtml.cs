using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab7PPTPM.Data;
using lab7PPTPM.Model;

namespace lab7PPTPM.Pages.PositionJob
{
    public class IndexModel : PageModel
    {
        private readonly lab7PPTPM.Data.lab7PPTPMContext _context;

        public IndexModel(lab7PPTPM.Data.lab7PPTPMContext context)
        {
            _context = context;
        }

        public IList<lab7PPTPM.Model.PositionJob> PositionJob { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PositionJob = await _context.PositionJob.ToListAsync();
        }
    }
}
