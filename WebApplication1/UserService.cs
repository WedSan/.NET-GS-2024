using Microsoft.EntityFrameworkCore;
using WebApplication1.model;

namespace WebApplication1;

public class UserService
{
    private readonly AppDbContext _repository;
    
        
    public UserService(AppDbContext entityRepository)
    {
        _repository = entityRepository;
    }

    public async Task<User> CreateUserAsync(string name, string email, string password, string telephone)
    {
        User user = new User
        (
            name,
            email,
            password,
            telephone
        );

        await _repository.Users.AddAsync(user);
        await _repository.SaveChangesAsync();
        return user;
    }

    public async Task DeleteUserAsync(int userId)
    {
        User? user = await GetUserByIdAsync(userId);

        _repository.Users.Remove(user);
        await _repository.SaveChangesAsync();
    }

    public async Task<User?> GetUserByIdAsync(int userId)
    {
        User? user = await _repository.Users.FindAsync(userId);
        return user;
    }

    public async Task<List<User?>> GetUsersAsync(int pageNumber, int pageSize)
    {
        return await _repository.Users
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}
