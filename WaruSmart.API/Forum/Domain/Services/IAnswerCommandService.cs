using WaruSmart.API.Forum.Domain.Model.Commands;
using WaruSmart.API.Forum.Domain.Model.Entities;

namespace WaruSmart.API.Forum.Domain.Services;

public interface IAnswerCommandService
{
    Task<Answer?> Handle(CreateAnswerCommand command);
    Task<Answer> Handle(UpdateAnswerCommand command);
    Task Handle(DeleteAnswerCommand command);
}