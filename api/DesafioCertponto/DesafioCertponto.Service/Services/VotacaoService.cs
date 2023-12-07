
using AutoMapper;
using DesafioCertponto.Application.DTO.DTO.Profissional;
using DesafioCertponto.Application.DTO.DTO.Restaurante;
using DesafioCertponto.Application.DTO.DTO.Votacao;
using DesafioCertponto.Domain.Entities;
using DesafioCertponto.Domain.Interfaces.Repositories;
using DesafioCertponto.Domain.Interfaces.Services;
using DesafioCertponto.Domain.Model;
using DesafioCertponto.Service.Validators;

namespace DesafioCertponto.Service.Services
{
    public class VotacaoService : BaseService<Votacao>, IServiceVotacao
    {
        private readonly IVotacaoRepository _votacaoRepository;
        private readonly IRestauranteVencedorRepository _restauranteVencedorRepository;
        private readonly IRestauranteRepository _restauranteRepository;
        private readonly IMapper _mapper;
        private readonly DateTime _today = DateTime.Now.Date;

        public VotacaoService(IVotacaoRepository votacaoRepository,IRestauranteRepository restauranteRepository ,IRestauranteVencedorRepository restauranteVencedorRepository, IMapper mapper) : base(votacaoRepository, mapper)
        {
            _votacaoRepository = votacaoRepository;
            _restauranteRepository = restauranteRepository;
            _restauranteVencedorRepository = restauranteVencedorRepository;
            _mapper = mapper;
        }
        public ApiResponse<VotacaoDTO> Add(VotacaoDTO votacaoDTO)
        {
            try
            {           
          
                bool profissionalCanVote = _votacaoRepository.IsProfissionalCanVote(votacaoDTO.ProfissionalID, _today);
                bool isRestauranteVotedInTheWeek = _restauranteVencedorRepository.isRestauranteWinnerOfWeek(votacaoDTO.RestauranteID, _today);
                if (!profissionalCanVote)
                    throw new Exception("Profissional já votou hoje!");
                if (isRestauranteVotedInTheWeek)
                    throw new Exception("Restaurante já foi votado na semana!");

                votacaoDTO.DataVotacao = _today;

                ApiResponse<VotacaoDTO> response = base.Add<VotacaoDTO, VotacaoDTO, VotacaoValidator>(votacaoDTO);
                var a = response.Data;
                bool isVotacaoFinished = _votacaoRepository.isVotacaoFinished(_today);
                if (isVotacaoFinished)
                {
                    int restauranteIdVencedor = _votacaoRepository.GetResults(_today);
                    if(restauranteIdVencedor > 0)          
                        _restauranteVencedorRepository.Add(new RestauranteVencedor { RestauranteID = restauranteIdVencedor, DataVotacao = _today });                           
                }

                return response;
            } catch(Exception ex)
            {
                return ApiResponse<VotacaoDTO>.ErrorResponse(ex.Message);
            }    
            
        }

        public ApiResponse<RestauranteDTO> GetResultadoVotacao()
        {
           var result =  _restauranteVencedorRepository.GetRestauranteWinnerOfWeek(_today);
            var restaurante = _restauranteRepository.GetById(result.RestauranteID);
            var mappedResult = _mapper.Map<RestauranteDTO>(result);
            mappedResult.Nome = restaurante.Nome;
            return ApiResponse<RestauranteDTO>.SuccessResponse(mappedResult);
        }

        public ApiResponse<IEnumerable<ProfissionalDTO>> GetProfissionaisDidntVote()
        {
            var result = _votacaoRepository.ProfissionalThatDidntVote(_today);
            var mappedResult = _mapper.Map<IEnumerable< ProfissionalDTO>> (result);
            return ApiResponse<IEnumerable<ProfissionalDTO>>.SuccessResponse(mappedResult);
        }
    }
}
