using AutoMapper;
using Movies_APIs.DTOs;
using Movies_APIs.Entities;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Helpers
{
    public class AutoMapperProfiles :Profile
    {

        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<GenresDTO, Genres>().ReverseMap();

            CreateMap<GenresCreationDTO, Genres>();

            CreateMap<ActorDTO, Actor>().ReverseMap();

            CreateMap<ActorCreationDTO, Actor>()
                .ForMember(s => s.Picture, options => options.Ignore());


            CreateMap<MoviesTheather, MoviesTheatherDTO>()
                .ForMember(s => s.Latitude, dto => dto.MapFrom(op => op.Location.Y))
               .ForMember(s => s.Longitude, dto => dto.MapFrom(op => op.Location.X));


            CreateMap<MoviesTheatherCreationDTO, MoviesTheather>()
                .ForMember(s => s.Location, x => x.MapFrom(dto => geometryFactory.CreatePoint(new Coordinate(dto.Longitude, dto.Latitude))));
        }
    }
}
