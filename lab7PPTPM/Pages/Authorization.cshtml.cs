using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab7PPTPM.Data;
using lab7PPTPM.Model;

namespace lab7PPTPM.Pages
{
    public class AuthorizationModel : PageModel
    {
        private readonly lab7PPTPM.Data.lab7PPTPMContext _context;

        public AuthorizationModel(lab7PPTPM.Data.lab7PPTPMContext context)
        {
            _context = context;
        }

        public lab7PPTPM.Model.Employee Employee { get; set; } = default!;

        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; } // Рекомендуется хранить хэш пароля
        }
        public async Task<IActionResult> OnPostAsync(string username, string password)
        {
            try
            {
                var user = await _context.Employee.FirstOrDefaultAsync(u => u.EmployeeLogin == username);

                if (user == null || user.EmployeePassword != password)
                {
                    ModelState.AddModelError(string.Empty, "Неверный логин или пароль");
                    return Page();
                }

                return RedirectToPage("/Employee/Index");
            }
            catch (Exception ex)
            {
                // Отладка: вывод сообщения об ошибке в консоль
                Console.WriteLine(ex.Message);
                return Page(); // Возврат на ту же страницу с ошибкой
            }
        }


    }
}
