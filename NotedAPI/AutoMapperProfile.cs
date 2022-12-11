using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NotedAPI.Dto;
using NotedAPI.Models;

namespace InternAppBE
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Note, GetNoteDto>();
            CreateMap<AddNoteDto, Note>();

        }
    }
}