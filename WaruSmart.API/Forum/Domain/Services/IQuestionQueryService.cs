using WaruSmart.API.Forum.Domain.Model.Aggregates;
using WaruSmart.API.Forum.Domain.Model.Queries;

namespace WaruSmart.API.Forum.Domain.Services;

public interface IQuestionQueryService
{
    Task<IEnumerable<Question>> Handle(GetAllQuestionsQuery query);
    Task<Question?> Handle(GetQuestionByIdQuery query);
    Task<IEnumerable<Question>> Handle(GetAllQuestionsByUserId query);
}