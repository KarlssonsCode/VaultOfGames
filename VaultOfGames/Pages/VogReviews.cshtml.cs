using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace VaultOfGames.Pages
{
    public class VogReviewsModel : PageModel
    {
        private readonly Data.VaultOfGamesContext _context;
        public VogReviewsModel(Data.VaultOfGamesContext context)
        {
            _context = context;
        }

        public List<Models.VogReview> VogReviews { get; set; }
        public List<Models.UserReview> UserReviews { get; set; }


        [BindProperty]
        public Models.VogReview VogReview { get; set; }
        [BindProperty]
        public Models.UserReview UserReview { get; set; }

        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        public async Task<IActionResult> OnGetAsync(int showid, int deleteid)
        {
            VogReviews = await _context.VogReview.ToListAsync();
            if (showid != 0)
            {
                VogReview = VogReviews.Where(p => p.Id == showid).FirstOrDefault();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {            
            if (UserReview.UserScore > 100)
            {
                UserReview.UserScore = 100;
            }
            if (UserReview.UserScore < 1)
            {
                UserReview.UserScore = 1;
            }

            UserReview.VogReviewId = VogReview.Id;

            _context.Add(UserReview);
            await _context.SaveChangesAsync();

            return RedirectToPage("./VogReview");
        }
    }
}
