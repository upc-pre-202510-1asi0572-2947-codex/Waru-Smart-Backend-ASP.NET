using WaruSmart.API.Forum.Domain.Model.Entities;
using WaruSmart.API.Forum.Domain.Model.Queries;

namespace WaruSmart.API.Forum.Domain.Services;

public interface IAnswerQueryService
{
    Task<IEnumerable<Answer>> Handle(GetAllAnswersQuery query);
    Task<Answer?> Handle(GetAnswerByIdQuery query);
    Task<IEnumerable<Answer>> Handle(GetAllAnswersByQuestionId query);
}