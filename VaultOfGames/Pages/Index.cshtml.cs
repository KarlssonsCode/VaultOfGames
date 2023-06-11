using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaultOfGames.Areas.Identity.Data;

namespace VaultOfGames.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<VaultOfGamesUser> _userManager;

        public VaultOfGamesUser VogUser { get; set; }

        public IndexModel (UserManager<VaultOfGamesUser> userManager)
        {
            _userManager = userManager;           
        }

        public async Task<IActionResult> OnGetAsync()
        {
            VogUser = await _userManager.GetUserAsync(User);
            return Page();
        }
    }
}