using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.model;

namespace WebApplication1.controller;
[ApiController]
[Route("api/v1/eletricity-history")]  
public class EletricityHistoryController : Controller
{
    private EletricityHistoryService _service;

    public EletricityHistoryController(EletricityHistoryService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<EletricityHistory>> CreateEletricityHistory([FromBody] AddEletricityHistoryDTO dto)
    {
        EletricityHistoryResponseDTO response = await _service.CreateHistoryEletricity(dto);
        return CreatedAtAction(nameof(CreateEletricityHistory), response);
    }

    [HttpGet("{eletricityHistoryId}")]
    public async Task<ActionResult> GetEletricityHistory(int eletricityHistoryId)
    {
        EletricityHistoryResponseDTO response = await _service.GetEletricityHistoryById(eletricityHistoryId);
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetEletricityHistory(int pageNumber, int pageSize)
    {
        IEnumerable<EletricityHistoryResponseDTO> responseList = await _service.GetAllEletricityHistory(pageNumber, pageSize);
        return Ok(responseList);
    }

    [HttpDelete("{eletricityHistoryId}")]
    public async Task<ActionResult> DeleteEletricityHistory(int eletricityHistoryId)
    {
        await _service.DeleteEletricityHistoryById(eletricityHistoryId);
        return NoContent();
    }
    
}