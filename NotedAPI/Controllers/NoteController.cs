using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotedAPI.Dto;
using NotedAPI.Models;
using NotedAPI.Services.Notes;
using System.ComponentModel.Design;

namespace NotedAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _noteService.Get());
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddNoteDto newNote)
        {
            return Ok(await _noteService.Add(newNote));
        }
    }
}
