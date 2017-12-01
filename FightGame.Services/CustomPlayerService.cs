using System;
using System.Collections.Generic;
using System.Linq;
using FightGame.Model;

namespace FightGame.Services
{
    public class CustomPlayerService : IPlayerService
    {
        private static List<Player> _players = new List<Player>();

        public Player AddPlayer(Player player)
        {
            player.Id = _players.Max(x => x.Id) + 1;
            _players.Add(player);

            return player;
        }

        public Player GetPlayerById(int id)
        {
            return _players.First(x => x.Id == id);
        }

        public List<Player> GetPlayers()
        {
            if (!_players.Any()) // players.Count == 0
            {
                _players = new List<Player>
                {
                    new Player
                    {
                        Id = 1,
                        Name = "Cat Woman",
                        Gender = Gender.Female,
                        Lives = GameModel.DefaultLives,
                        Power = GameModel.DefaultPower
                    },
                    new Player
                    {
                        Id = 2,
                        Name = "Lobezno",
                        Gender = Gender.Male,
                        Lives = GameModel.DefaultLives,
                        Power = GameModel.DefaultPower
                    },
                    new Player
                    {
                        Id = 3,
                        Name = "Wonder Woman",
                        Gender = Gender.Female,
                        Lives = GameModel.DefaultLives,
                        Power = GameModel.DefaultPower
                    },
                    new Player
                    {
                        Id = 4,
                        Name = "Batman",
                        Gender = Gender.Male,
                        Lives = GameModel.DefaultLives,
                        Power = GameModel.DefaultPower
                    },
                };
            }

            return _players;
        }

        public Player UpdatePlayer(Player player)
        {
            var matching = _players.FirstOrDefault(x => x.Id == player.Id);

            if(matching != null)
            {
                matching.Lives = player.Lives;
                matching.Power = player.Power;
                matching.Name = player.Name;
                matching.Gender = player.Gender;
                matching.Gems = player.Gems;

                return matching;
            }

            throw new Exception("Jugador no encontrado");
        }

        public void Delete(int id)
        {
            var player = _players.First(x => x.Id == id);
            _players.Remove(player);
        }
    }
}
