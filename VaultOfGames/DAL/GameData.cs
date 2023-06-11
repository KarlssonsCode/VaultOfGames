using System.Text.Json;

namespace VaultOfGames.DAL
{
    public class GameData
    {
        public static async Task<List<Models.Game>> GetGames()
        {
            List<Models.Game> games = null;

            using (var client = new HttpClient())
            {               
                client.BaseAddress = new Uri("https://vaultofgamesapi.azurewebsites.net/api/games");

                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    games = JsonSerializer.Deserialize<List<Models.Game>>(responseString);
                }


            }
            return games;

        }
    }
}
