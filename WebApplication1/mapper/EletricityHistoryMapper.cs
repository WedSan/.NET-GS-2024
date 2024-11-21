using WebApplication1.DTO;
using WebApplication1.model;

namespace WebApplication1.mapper;

public class EletricityHistoryMapper
{
    public static EletricityHistoryResponseDTO ToDTO(EletricityHistory history)
    {
        return new EletricityHistoryResponseDTO(
            history.id,
            history.address.id,
            history.eletricityConsumption,
            history.unitMeasurement,
            history.registrationDate,
            history.cost
        );
    }
    
    public static IEnumerable<EletricityHistoryResponseDTO> ToDTO(IEnumerable<EletricityHistory> historyList)
    {
        List<EletricityHistoryResponseDTO> dtoList = new List<EletricityHistoryResponseDTO>();

        foreach (var history in historyList)
        {
            dtoList.Add(ToDTO(history));
        }
        
        return dtoList;
    }
}