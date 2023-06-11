using Microsoft.AspNetCore.SignalR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VaultOfGames.Models
{
    public class UserReview
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [DisplayName("Description")]
        public string UserReviewDescription { get; set; }

        [DisplayName("Score 1-100")]
        [Range(1, 100)]
        public int UserScore { get; set; }
        public int VogReviewId { get; set; }

    }
}
