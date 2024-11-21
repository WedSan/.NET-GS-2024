using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;
using WebApplication1.exception;
using WebApplication1.mapper;
using WebApplication1.model;

namespace WebApplication1;

public class EletricityHistoryService
{
    private AppDbContext _repository;
    
    private AddressService _addressService;

    public EletricityHistoryService(AppDbContext repository, AddressService addressService)
    {
        _repository = repository;
        _addressService = addressService;
    }

    public async Task<EletricityHistoryResponseDTO> CreateHistoryEletricity(AddEletricityHistoryDTO eletricityHistoryDTO)
    {
        
        Address addressFounded = await _addressService.FindAddressByIdAsync(eletricityHistoryDTO.addressId);
        
        EletricityHistory eletricityHistory = new EletricityHistory(
            addressFounded,
            eletricityHistoryDTO.eletricityConsumption,
            eletricityHistoryDTO.unitMeasurement,
            eletricityHistoryDTO.registrationDate,
            eletricityHistoryDTO.cost
            );
        
        _repository.EletricityHistories.Add(eletricityHistory);
        await _repository.SaveChangesAsync();
        return EletricityHistoryMapper.ToDTO(eletricityHistory);
    }
    
    public async Task<IEnumerable<EletricityHistoryResponseDTO>> GetAllEletricityHistory(int pageNumber, int pageSize)
    {
        IEnumerable<EletricityHistory> eletricityHistories = await _repository.EletricityHistories
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return EletricityHistoryMapper.ToDTO(eletricityHistories);
    }
    
    public async Task<EletricityHistoryResponseDTO> GetEletricityHistoryById(int eletricityId)
    {
        EletricityHistory eletricityHistory = await FindEletricityHistoryByid(eletricityId);
        return EletricityHistoryMapper.ToDTO(eletricityHistory);
    }
    
    private async Task<EletricityHistory> FindEletricityHistoryByid(int addressId)
    {
        EletricityHistory? eletricityHistory = await _repository.EletricityHistories.FindAsync(addressId);

        if (eletricityHistory == null)
        {
            throw new EntityNotFoundException("Eletricity History Not Found");
        }
        
        return eletricityHistory;
    }

    public async Task DeleteEletricityHistoryById(int eletricityHistoryId)
    {
        EletricityHistory eletricityHistoryFounded = await FindEletricityHistoryByid(eletricityHistoryId);
        _repository.EletricityHistories.Remove(eletricityHistoryFounded);
        await _repository.SaveChangesAsync();
    }
}