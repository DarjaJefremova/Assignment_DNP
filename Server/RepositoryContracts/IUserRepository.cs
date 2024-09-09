namespace RepositoryContracts;
using Entities;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
    Task GetSingleAsync(int id);
    IQueryable<User> GetMany();
}