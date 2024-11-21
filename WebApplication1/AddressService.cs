using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;
using WebApplication1.exception;
using WebApplication1.mapper;
using WebApplication1.model;

namespace WebApplication1;

public class AddressService
{
    private readonly AppDbContext _repository;
    
    private UserService _userService;

    public AddressService(AppDbContext repository, UserService userService)
    {
        _repository = repository;
        _userService = userService;
    }

    public async Task<AddressResponse> CreateAddressAsync(
        int userID,

        string street,
        
        string neighborhood,

        string postalCode,
        
        string houseNumber,
        
        string city,
        
        string localType)
    {
        postalCode = postalCode.Replace("-", "");
        User user = await _userService.GetUserByIdAsync(userID);
        Address address = new Address(
            user,
            street,
            neighborhood,
            postalCode,
            houseNumber,
            city,
            localType
        );
        await _repository.Addresses.AddAsync(address);
        await _repository.SaveChangesAsync();
        return AddressMapper.toDTO(address);
    }

    public async Task<IEnumerable<AddressResponse>> GetAddressesAsync(int pageNumber, int pageSize)
    {
        IEnumerable<Address> addresses = await _repository.Addresses.
            Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return AddressMapper.toDTO(addresses);
    }
    
    public async Task<AddressResponse> GetAddressByIdAsync(int addressId)
    {
       
        Address address = await FindAddressByIdAsync(addressId);
        return AddressMapper.toDTO(address);
    }

    public async Task DeleteAddressAsync(int addressId)
    {
        Address address = await FindAddressByIdAsync(addressId);
        _repository.Addresses.Remove(address);
        await _repository.SaveChangesAsync();
    }

    public async Task<Address> FindAddressByIdAsync(int userId)
    {
        Address? addressFounded = await _repository.Addresses.FindAsync(userId);
        if (addressFounded == null)
        {
            throw new EntityNotFoundException("Address not found");
        }

        return addressFounded;
    }
}