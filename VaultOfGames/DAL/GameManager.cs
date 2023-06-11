namespace VaultOfGames.DAL
{
    public class GameManager
    {
        public static List<Models.Game> Games { get; set; }

        public static async Task<List<Models.Game>> GetAllProducts()
        {
            if (Games == null || !Games.Any())
            {
                Games = await GameData.GetGames();
            }

            return Games;
        }
    }
}
