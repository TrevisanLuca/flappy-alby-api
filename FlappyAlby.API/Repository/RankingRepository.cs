using Bogus;
using FlappyAlby.API.Abstract;
using FlappyAlby.API.Domain;
using FlappyAlby.API.DTOs;
using System.Collections.Generic;

namespace FlappyAlby.API.Repository
{
    public class RankingRepository : IRankingRepository
    {        
        private readonly IReader _reader;
        private readonly IWriter _writer;

        public RankingRepository(IReader reader, IWriter writer)
        {         
            _reader = reader;
            _writer = writer;
        }       

        public async Task<IEnumerable<Player>> GetRanking()
        {
            const string query = @"SELECT TOP 10 Name, Total, Id
                                   FROM Score
                                   ORDER BY Total ASC"; 
            var players = await _reader.QueryTEntityAsync<Player>(query);
            return players;
        }

        public async Task<int?> CreatePlayer(PlayerDto player)
        {
            const string query = @"INSERT 
                                   INTO Score(Name,Total)
                                   OUTPUT inserted.Id
                                   VALUES (@Name,@Total)";
            var newPlayer = new Player(player.Name, player.Total);
            var result = await _writer.WriteInDBAsync<Player>(query, newPlayer);
            return result;
        }
    }
}