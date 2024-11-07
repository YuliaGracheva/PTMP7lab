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
    public class DetailsModel : PageModel
    {
        private readonly lab7PPTPM.Data.lab7PPTPMContext _context;

        public DetailsModel(lab7PPTPM.Data.lab7PPTPMContext context)
        {
            _context = context;
        }

        public lab7PPTPM.Model.PositionJob PositionJob { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionjob = await _context.PositionJob.FirstOrDefaultAsync(m => m.PositionJobId == id);
            if (positionjob == null)
            {
                return NotFound();
            }
            else
            {
                PositionJob = positionjob;
            }
            return Page();
        }
    }
}
