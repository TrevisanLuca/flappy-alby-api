using FlappyAlby.API.Domain;

namespace FlappyAlby.API.Abstract;

public interface IWriter
{
    Task<int?> WriteInDBAsync<TDto>(string query, TDto objectToWrite) where TDto : EntityBase;
    Task<int> DeleteInDBAsync(string query, object parameters);
}