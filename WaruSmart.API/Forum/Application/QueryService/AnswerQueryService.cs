using WaruSmart.API.Forum.Domain.Model.Entities;
using WaruSmart.API.Forum.Domain.Model.Queries;
using WaruSmart.API.Forum.Domain.Repositories;
using WaruSmart.API.Forum.Domain.Services;

namespace WaruSmart.API.Forum.Application.QueryService;

public class AnswerQueryService(IAnswerRepository answerRepository) : IAnswerQueryService
{
    public async Task<IEnumerable<Answer>> Handle(GetAllAnswersQuery query)
    {
        return await answerRepository.ListAsync();
    }

    public async Task<Answer?> Handle(GetAnswerByIdQuery query)
    {
        return await answerRepository.FindByIdAsync(query.AnswerId);
    }

    public async Task<IEnumerable<Answer>> Handle(GetAllAnswersByQuestionId query)
    {
        return await answerRepository.FindByQuestionIdAsync(query.QuestionId);
    }
}