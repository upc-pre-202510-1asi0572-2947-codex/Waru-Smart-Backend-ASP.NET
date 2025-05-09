using WaruSmart.API.Forum.Domain.Model.Aggregates;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Forum.Domain.Repositories;

public interface IQuestionRepository : IBaseRepository<Question>
{
    Task<IEnumerable<Question>> FindByUserIdAsync(int authorId);
    bool ExistsByQuestionText(string questionText);
}