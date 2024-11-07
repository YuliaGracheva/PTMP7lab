using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using lab7PPTPM.Data;
using lab7PPTPM.Model;

namespace lab7PPTPM.Pages.PositionJob
{
    public class CreateModel : PageModel
    {
        private readonly lab7PPTPM.Data.lab7PPTPMContext _context;

        public CreateModel(lab7PPTPM.Data.lab7PPTPMContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public lab7PPTPM.Model.PositionJob PositionJob { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PositionJob.Add(PositionJob);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
