using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab7PPTPM.Data;
using lab7PPTPM.Model;

namespace lab7PPTPM.Pages.PositionJob
{
    public class EditModel : PageModel
    {
        private readonly lab7PPTPM.Data.lab7PPTPMContext _context;

        public EditModel(lab7PPTPM.Data.lab7PPTPMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public  lab7PPTPM.Model.PositionJob PositionJob { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionjob =  await _context.PositionJob.FirstOrDefaultAsync(m => m.PositionJobId == id);
            if (positionjob == null)
            {
                return NotFound();
            }
            PositionJob = positionjob;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PositionJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionJobExists(PositionJob.PositionJobId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PositionJobExists(int id)
        {
            return _context.PositionJob.Any(e => e.PositionJobId == id);
        }
    }
}
