
using AutoMapper;
using DesafioCertponto.Domain.Interfaces.Repositories;
using DesafioCertponto.Domain.Interfaces.Services;
using DesafioCertponto.Domain.Model;
using FluentValidation;

namespace DesafioCertponto.Service.Services
{
    public abstract class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual ApiResponse<TOutputModel> Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            try
            {
                TEntity entity = _mapper.Map<TEntity>(inputModel);
                Validate(entity, Activator.CreateInstance<TValidator>());
                _repository.Add(entity);
                TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);
                return ApiResponse<TOutputModel>.SuccessResponse(outputModel);
            }
            catch (ValidationException ex)
            {
                return ApiResponse<TOutputModel>.ErrorResponse(string.Join(", ", ex.Errors.Select(error => error.ErrorMessage)));
            }
            catch (Exception ex)
            {
                return ApiResponse<TOutputModel>.ErrorResponse(ex.Message);
            }
        }

        public virtual ApiResponse<TEntity> GetById(int id)
        {
            try
            {
                TEntity entity = _repository.GetById(id);
                return ApiResponse<TEntity>.SuccessResponse(entity);
            }
            catch (Exception ex)
            {
                return ApiResponse<TEntity>.ErrorResponse(ex.Message);
            }
        }

        public virtual ApiResponse<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                IEnumerable<TEntity> entities = _repository.GetAll();
                return ApiResponse<IEnumerable<TEntity>>.SuccessResponse(entities);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<TEntity>>.ErrorResponse(ex.Message);
            }
        }

        public virtual ApiResponse<TOutputModel> Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            try
            {
                TEntity entity = _mapper.Map<TEntity>(inputModel);
                Validate(entity, Activator.CreateInstance<TValidator>());
                _repository.Update(entity);
                TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);
                return ApiResponse<TOutputModel>.SuccessResponse(outputModel);
            }
            catch (ValidationException ex)
            {
                return ApiResponse<TOutputModel>.ErrorResponse(string.Join(", ", ex.Errors.Select(error => error.ErrorMessage)));
            }
            catch (Exception ex)
            {
                return ApiResponse<TOutputModel>.ErrorResponse(ex.Message);
            }
        }

        public virtual ApiResponse<bool> Remove(int id)
        {
            try
            {
                _repository.Remove(id);
                return ApiResponse<bool>.SuccessResponse(true);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse(ex.Message);
            }
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }

}
