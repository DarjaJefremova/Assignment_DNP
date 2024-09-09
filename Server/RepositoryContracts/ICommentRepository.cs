namespace RepositoryContracts;
using Entities;

public interface ICommentRepository
{
    Task AddAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(int id);
    Task GetSingleAsync(int id);
    IQueryable<Comment> GetMany();
}