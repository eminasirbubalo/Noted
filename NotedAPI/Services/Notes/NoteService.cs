using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotedAPI.Data;
using NotedAPI.Dto;
using NotedAPI.Models;
using System.Security.Claims;

namespace NotedAPI.Services.Notes
{
    public class NoteService : INoteService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NoteService(DataContext context,IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<List<GetNoteDto>>> Add(AddNoteDto newNote)
        {
            var serviceResponse = new ServiceResponse<List<GetNoteDto>>();
            var note = _mapper.Map<Note>(newNote);
            note.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Notes.Select(note => _mapper.Map<GetNoteDto>(note)).ToListAsync();
            return serviceResponse;
        }

        public Task<ServiceResponse<List<GetNoteDto>>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetNoteDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetNoteDto>>> Get()
        {
            var serviceResponse = new ServiceResponse<List<GetNoteDto>>();
            var notes = await _context.Notes.Where(c => c.User.Id == GetUserId()).Include(note => note.User).ToListAsync();
            serviceResponse.Data = notes.Select(notes => _mapper.Map<GetNoteDto>(notes)).ToList();
            return serviceResponse;

        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
