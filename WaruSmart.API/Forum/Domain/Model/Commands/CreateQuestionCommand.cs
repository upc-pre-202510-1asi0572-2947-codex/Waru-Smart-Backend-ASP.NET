﻿namespace WaruSmart.API.Forum.Domain.Model.Commands;

public record CreateQuestionCommand(int AuthorId, int CategoryId, string QuestionText, DateTime Date);