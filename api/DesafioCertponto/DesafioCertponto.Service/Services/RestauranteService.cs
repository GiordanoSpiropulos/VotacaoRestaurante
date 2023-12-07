using AutoMapper;
using DesafioCertponto.Application.DTO.DTO.Restaurante;
using DesafioCertponto.Domain.Entities;
using DesafioCertponto.Domain.Interfaces.Repositories;
using DesafioCertponto.Domain.Interfaces.Services;
using DesafioCertponto.Domain.Model;
using DesafioCertponto.Service.Validators;

namespace DesafioCertponto.Service.Services
{
    public class RestauranteService : BaseService<Restaurante>, IServiceRestaurante
    {
        private readonly IRestauranteRepository _repositoryRestaurante;
        private readonly IMapper _mapper;

        public RestauranteService(IRestauranteRepository repositoryRestaurante, IMapper mapper)
            : base(repositoryRestaurante, mapper)
        {
            _repositoryRestaurante = repositoryRestaurante;
            _mapper = mapper;
        }

        public ApiResponse<RestauranteDTO> Add(RestauranteDTO restauranteDTO)
        {
            return base.Add<RestauranteDTO, RestauranteDTO, RestauranteValidator>(restauranteDTO);
        }

        public ApiResponse<RestauranteDTO> Update(RestauranteDTO restauranteDTO)
        {
            return base.Update<RestauranteDTO, RestauranteDTO, RestauranteValidator>(restauranteDTO);
        }
    }
}
