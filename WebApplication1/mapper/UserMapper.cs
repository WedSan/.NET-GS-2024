using WebApplication1.DTO;
using WebApplication1.model;

namespace WebApplication1.mapper;

public class UserMapper
{
    public static UserEntityResponse ToDTO(User user)
    {
        return new UserEntityResponse
        (
            user.Id,
            user.Name,
            user.Email,
            user.Telephone
        );
    }

    public static List<UserEntityResponse> ToDTO(List<User?> users)
    {
        return users.Select(user => new UserEntityResponse(
            user.Id,
            user.Name,
            user.Email,
            user.Telephone
        )).ToList();
    }
}

