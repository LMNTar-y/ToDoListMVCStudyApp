using FluentValidation;
using ToDoList.Infrastructure.Models;

namespace ToDoList.Core.Validators;

public class ToDoValidator : AbstractValidator<ToDo>
{
    public ToDoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(255).MinimumLength(5);
        RuleFor(x => x.DateTime).NotEmpty().GreaterThan(DateTime.Now);
    }
}