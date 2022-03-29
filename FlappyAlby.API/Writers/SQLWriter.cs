namespace FlappyAlby.API.Writers;

using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using Abstract;
using Options;
using FlappyAlby.API.Domain;

public class SQLWriter : IWriter
{
    private readonly string _connectionstring;
    public SQLWriter(IOptions<ConnectionStringOptions> options) => _connectionstring = options.Value.DefaultDatabase;

    public async Task<int?> WriteInDBAsync<TDto>(string query, TDto objectToWrite) where TDto : EntityBase =>
        (await new SqlConnection(_connectionstring).ExecuteScalarAsync(query, objectToWrite, commandTimeout: 10)) as int?;

    public async Task<int> DeleteInDBAsync(string query, object parameters)
    {
        try
        {
            return await new SqlConnection(_connectionstring).ExecuteAsync(query, parameters);
        }
        catch (Exception)
        {
            return 0;
        }
    }
}