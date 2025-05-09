using WaruSmart.API.Forum.Domain.Model.Aggregates;
using WaruSmart.API.Forum.Domain.Model.Commands;

namespace WaruSmart.API.Forum.Domain.Services;

public interface IQuestionCommandService
{
    Task<Question?> Handle(CreateQuestionCommand command);
    Task<Question> Handle(UpdateQuestionCommand command);
    Task Handle(DeleteQuestionCommand command);
}