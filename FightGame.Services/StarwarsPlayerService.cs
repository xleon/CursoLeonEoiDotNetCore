using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using FightGame.Model;
using Newtonsoft.Json;

namespace FightGame.Services
{
    public class StarwarsPlayerService : IPlayerService
    {
        private static List<Player> _players = new List<Player>();

        private const string ApiUrl = "https://swapi.co/api/people/";

        public Player AddPlayer(Player player)
        {
            player.Id = GetPlayers().Max(x => x.Id) + 1;
            _players.Add(player);

            return player;
        }

        public Player GetPlayerById(int id)
        {
            return _players.First(x => x.Id == id);
        }

        public List<Player> GetPlayers()
        {
            if(!_players.Any())
            {
                var httpClient = new HttpClient();
                var result = httpClient.GetStringAsync(ApiUrl).Result;
                StartWarsPeople people = JsonConvert.DeserializeObject<StartWarsPeople>(result);

                var lastId = 0;
                var players = people.Results.Select(person => new Player
                {
                    Id = ++lastId,
                    Name = person.PlayerName,
                    Gender = person.PlayerGender == "male" ? Gender.Male : Gender.Female,
                    Lives = GameModel.DefaultLives,
                    Power = GameModel.DefaultPower
                });

                _players = players.ToList();
            }

            return _players;
        }

        public Player UpdatePlayer(Player player)
        {
            var matching = _players.FirstOrDefault(x => x.Id == player.Id);

            if (matching != null)
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
