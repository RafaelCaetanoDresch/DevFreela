﻿using DevFreela.Application.Commands.CreateUser;
using System.Text.RegularExpressions;

namespace DevFreela.Application.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.Email)
            .EmailAddress()
            .WithMessage("Email obrigatório");

        RuleFor(p => p.Password)
            .Must(ValidPassword)
            .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula e um número");

        RuleFor(p => p.FullName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome é obrigatório!");
    }

    public bool ValidPassword(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
        return regex.IsMatch(password);
    }
}
