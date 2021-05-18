using AutoMapper;
using Movies_APIs.DTOs;
using Movies_APIs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Helpers
{
    public class AutoMapperProfiles :Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<GenresDTO, Genres>().ReverseMap();

            CreateMap<GenresCreationDTO, Genres>();

            CreateMap<ActorDTO, Actor>().ReverseMap();

            CreateMap<ActorCreationDTO, Actor>()
                .ForMember(s => s.Picture, options => options.Ignore());
        }
    }
}
