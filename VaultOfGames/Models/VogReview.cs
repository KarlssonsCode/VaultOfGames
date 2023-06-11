using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VaultOfGames.Models
{
    public class VogReview
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [DisplayName("Game")]
        public string GameTitle { get; set; }
        [DisplayName("Title of Review")]
        public string ReviewTitle { get; set; }
        [DisplayName("Review Description")]
        public string ReviewDescription { get; set;}
        
        [Range(1,100)]
        public int VogScore { get; set; }
        public int GameId { get; set; }
        public string Image { get; set; }

    }
}
