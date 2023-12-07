using DesafioCertponto.Domain.Model;
using FluentValidation;

namespace DesafioCertponto.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        ApiResponse<TOutputModel> Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
                where TValidator : AbstractValidator<TEntity>
               where TInputModel : class
               where TOutputModel : class;

        ApiResponse<TEntity> GetById(int id);

        ApiResponse<IEnumerable<TEntity>> GetAll();

        ApiResponse<TOutputModel> Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
      where TValidator : AbstractValidator<TEntity>
      where TInputModel : class
      where TOutputModel : class;

        ApiResponse<bool> Remove(int id);

        void Dispose();
    }
}