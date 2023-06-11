using System.Text.Json.Serialization;

namespace VaultOfGames.Models
{
    public class Game
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("gameTitle")]
        public string GameTitle { get; set; }
        [JsonPropertyName("developer")]
        public string Developer { get; set; }
    }
}
