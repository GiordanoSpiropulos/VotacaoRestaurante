

using AutoMapper;
using DesafioCertponto.Application.DTO.DTO.Profissional;
using DesafioCertponto.Domain.Entities;
using DesafioCertponto.Domain.Interfaces.Repositories;
using DesafioCertponto.Domain.Interfaces.Services;
using DesafioCertponto.Domain.Model;
using DesafioCertponto.Service.Validators;

namespace DesafioCertponto.Service.Services
{
    public class ProfissionalService : BaseService<Profissional>, IServiceProfissional
    {
        private readonly IProfissionalRepository _repositoryProfissional;
        private readonly IMapper _mapper;

        public ProfissionalService(IProfissionalRepository profissionalRepository, IMapper mapper)
            : base(profissionalRepository, mapper)
        {
            _repositoryProfissional = profissionalRepository;
            _mapper = mapper;
        }

        public ApiResponse<ProfissionalDTO> Add(ProfissionalDTO profissionalDTO)
        {
            return base.Add<ProfissionalDTO, ProfissionalDTO, ProfissionalValidator>(profissionalDTO);
        }

        public ApiResponse<ProfissionalDTO> Update(ProfissionalUpdateDTO profissionalUpdateDTO)
        {
            return base.Update<ProfissionalUpdateDTO, ProfissionalDTO, ProfissionalValidator>(profissionalUpdateDTO);
        }

    }
}
