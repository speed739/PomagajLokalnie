using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        
        [BindProperty]
        public InputModel Input { get; set; }

        public RegisteryModel(PomagajLokalnieContext context)
        {
            _context = context;
            Input = new InputModel();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public User User { get => _user; set => _user = value; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var User = new User() 
            {
                Login = Input.Login,
                Password = Input.Password,
                Roles = Input.Roles
            };


            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public class InputModel
        {
            [Required] [Display(Name = "Type")] public string Roles { get; set; }

            [Required] [Display(Name = "Login")] public string Login { get; set; }

            [Required] [Display(Name = "Password")] public string Password { get; set; }

        }
    }
}
