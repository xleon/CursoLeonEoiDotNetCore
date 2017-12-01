using System.Collections.Generic;
using FightGame.Model;

namespace FightGame.Services
{
    public interface IPlayerService
    {
        List<Player> GetPlayers();

        Player GetPlayerById(int id);

        Player AddPlayer(Player player);

        Player UpdatePlayer(Player player);

        void Delete(int id);
    }
}
