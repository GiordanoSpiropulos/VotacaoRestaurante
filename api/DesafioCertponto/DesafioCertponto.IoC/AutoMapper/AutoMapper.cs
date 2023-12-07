using AutoMapper;
using DesafioCertponto.Application.DTO.DTO.Profissional;
using DesafioCertponto.Application.DTO.DTO.Restaurante;
using DesafioCertponto.Application.DTO.DTO.Votacao;
using DesafioCertponto.Domain.Entities;

namespace DesafioCertponto.Crosscutting.IoC.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Profissional, ProfissionalDTO>();
            CreateMap<Profissional, ProfissionalUpdateDTO>();
            CreateMap<ProfissionalDTO, Profissional>();
            CreateMap<ProfissionalUpdateDTO, Profissional>();
            CreateMap<ProfissionalUpdateDTO, ProfissionalDTO>();

            CreateMap<Restaurante, RestauranteDTO>();
            CreateMap<Restaurante, RestauranteUpdateDTO>();
            CreateMap<RestauranteDTO, Restaurante>();
            CreateMap<RestauranteUpdateDTO, Restaurante>();

            CreateMap<Votacao, VotacaoDTO>();
            CreateMap<VotacaoDTO, Votacao>();

            CreateMap<RestauranteVencedor, RestauranteDTO>();
        }
    }
}
