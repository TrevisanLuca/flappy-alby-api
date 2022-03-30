namespace FlappyAlby.API.Abstract;

using FlappyAlby.API.Domain;

public interface IWriter
{
    Task<int> WriteAsync<TDto>(string query, TDto objectToWrite) where TDto : EntityBase;
    Task<int> DeleteInDBAsync(string query, object parameters);
}