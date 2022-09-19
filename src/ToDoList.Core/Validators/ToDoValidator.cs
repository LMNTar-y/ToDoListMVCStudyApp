using FluentValidation;
using ToDoList.Infrastructure.Models;

namespace ToDoList.Core.Validators;

public class ToDoValidator : AbstractValidator<ToDo>
{
    public ToDoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(255).MinimumLength(5);
    }
}