using WaruSmart.API.Forum.Domain.Model.Aggregates;
using WaruSmart.API.Forum.Domain.Model.Queries;
using WaruSmart.API.Forum.Domain.Repositories;
using WaruSmart.API.Forum.Domain.Services;

namespace WaruSmart.API.Forum.Application.QueryService;

public class QuestionQueryService(IQuestionRepository questionRepository) : IQuestionQueryService
{
    public async Task<IEnumerable<Question>> Handle(GetAllQuestionsQuery query)
    {
        return await questionRepository.ListAsync();
    }

    public async Task<Question?> Handle(GetQuestionByIdQuery query)
    {
        return await questionRepository.FindByIdAsync(query.QuestionId);
    }

    public async Task<IEnumerable<Question>> Handle(GetAllQuestionsByUserId query)
    {
        return await questionRepository.FindByUserIdAsync(query.AuthorId);
    }
}