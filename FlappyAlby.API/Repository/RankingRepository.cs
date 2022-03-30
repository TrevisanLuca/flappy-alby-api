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

        public async Task<IEnumerable<PlayerDto>> GetRanking()
        {
            const string query = @"SELECT TOP 10 Name, Total, Id
                                   FROM Score
                                   ORDER BY Total ASC"; 
            var players = await _reader.QueryTEntityAsync<PlayerDto>(query);
            return players;
        }

        public async Task<PlayerDto> GetById(int id)
        {
            const string query = @"SELECT Name, Total, Id
                                   FROM Score
                                   WHERE Id=@Id";
            var result = await _reader.QuerySingleTEntityAsync<PlayerDto>(query, new {Id = id});
            return result;
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