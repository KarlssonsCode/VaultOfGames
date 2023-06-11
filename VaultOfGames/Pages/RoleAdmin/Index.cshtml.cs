using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VaultOfGames.Areas.Identity.Data;

namespace VaultOfGames.Pages.RoleAdmin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        public List<VaultOfGamesUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }

        [BindProperty]
        public string RoleName { get; set; }



        [BindProperty(SupportsGet = true)]
        public string AddUserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RemoveUserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Role { get; set; }


        public bool IsUser { get; set; }
        public bool IsAdmin { get; set; }


        public readonly UserManager<VaultOfGamesUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;



        public IndexModel(RoleManager<IdentityRole> roleManager, UserManager<VaultOfGamesUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            Roles = await _roleManager.Roles.ToListAsync();
            Users = await _userManager.Users.ToListAsync();

            if (AddUserId != null)
            {
                var alterUser = await _userManager.FindByIdAsync(AddUserId);
                var roleresult = await _userManager.AddToRoleAsync(alterUser, Role);
            }

            if (RemoveUserId != null)
            {
                var alterUser = await _userManager.FindByIdAsync(RemoveUserId);
                var roleresult = await _userManager.RemoveFromRoleAsync(alterUser, Role);
            }

            // Demo av roller


            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                IsUser = await _userManager.IsInRoleAsync(currentUser, "User");
                IsAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (RoleName != null)
            {
                await CreateRole(RoleName);
            }
            return RedirectToPage("./Index");
        }

        public async Task CreateRole(string roleName)
        {
            bool exist = await _roleManager.RoleExistsAsync(roleName);
            if (!exist)
            {
                var Role = new IdentityRole
                {
                    Name = roleName
                };

                await _roleManager.CreateAsync(Role);
            }
        }
    }
}
