using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata;
using System.Security.Claims;
using VaultOfGames.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace VaultOfGames.Pages
{
    [Authorize(Roles = " Admin")]
    public class AddVogReviewModel : PageModel
    {
        private readonly Data.VaultOfGamesContext _context;
        public AddVogReviewModel(Data.VaultOfGamesContext context)
        {
            _context = context;
        }

        public List<Models.Game> Games { get; set; }
        public Models.Game Game { get; set; }

        [BindProperty]
        public Models.VogReview VogReview { get; set; }
        [BindProperty]
        public IFormFile UploadedImage { get; set; }




        public async Task<IActionResult> OnGetAsync(int showid, int id, int deleteid)
        {
            Games = await DAL.GameManager.GetAllProducts();
   
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string fileName = string.Empty;

            if (UploadedImage != null)
            {
                Random rnd = new();
                fileName = rnd.Next(0, 100000).ToString() + UploadedImage.FileName;
                var file = "./wwwroot/img/" + fileName;
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await UploadedImage.CopyToAsync(fileStream);
                }
            }

            if(VogReview.VogScore > 100)
            {
                VogReview.VogScore = 100;
            }
            if(VogReview.VogScore < 1)
            {
                VogReview.VogScore = 1;
            }

            VogReview.Image = fileName;
            //VogReview.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            _context.Add(VogReview);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}

