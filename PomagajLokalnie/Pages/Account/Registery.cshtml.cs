using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PomagajLokalnie.Enums;
using PomagajLokalnie.Models;

namespace PomagajLokalnie.Pages.Account
{
    public class RegisteryModel : PageModel
    {
        private readonly PomagajLokalnieContext _context;
        private User _user;
        public Roles rolesEnum;

        public RegisteryModel(PomagajLokalnieContext context)
        {
            _context = context;
           
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get => _user; set => _user = value; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
