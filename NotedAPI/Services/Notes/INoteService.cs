using NotedAPI.Dto;
using NotedAPI.Models;

namespace NotedAPI.Services.Notes
{
    public interface INoteService 
    {
        Task<ServiceResponse<List<GetNoteDto>>> Add(AddNoteDto newNote);
        Task<ServiceResponse<GetNoteDto>> GetById(int id);
        Task<ServiceResponse<List<GetNoteDto>>> Get();
        Task<ServiceResponse<List<GetNoteDto>>> Delete(int id);
    }
}
