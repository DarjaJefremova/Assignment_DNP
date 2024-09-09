namespace RepositoryContracts;
using Entities;

public interface IPostRepository
{
    Task AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(int id);
    Task GetSingleAsync(int id);
    IQueryable<Post> GetMany();
}