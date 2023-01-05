using dotnet_mvc.Models;
using FluentValidation;
using FluentValidation.Results;
using WebApi;

namespace Validator;
public class userValidator : AbstractValidator <User> 
{
public userValidator()
  {
    RuleFor(User => User.name).NotEmpty()
    .WithMessage("O nome deve ser preenchido.")
    .Length(3, 100)
    .WithMessage("O nome deve ter entre 3 e 100 caracteres.");
    //--------------------------------------------------------------------------
    RuleFor(User => User.phoneNumber).NotEmpty()
    .WithMessage("O phoneNumber deve ser preenchido.")
    .Length(11)
    .WithMessage("O phoneNumber deve ter entre 11 caracteres.");
    //--------------------------------------------------------------------------
    RuleFor(User => User.email).NotEmpty()
    .WithMessage("O email deve ser preenchido.")
    .EmailAddress()//Obriga que o Email tenha um "@" e um ".com".
    .WithMessage("O email deve ser válido.")
    .Length(10, 70)
    .WithMessage("O email deve ter entre 10 e 70 caracteres.");
    //--------------------------------------------------------------------------
    RuleFor(User => User.companyName).NotEmpty()
    .WithMessage("O companyName deve ser preenchido.")
    .Length(3, 140)
    .WithMessage("O companyName deve ter entre 3 e 140 caracteres.");
    //--------------------------------------------------------------------------
    RuleFor(User => User.password).NotEmpty()
    .WithMessage("O Password deve ser preenchido.")
    .Length(8, 60)
    .WithMessage("O Password deve ter entre 8 e 60 caracteres.");
    //--------------------------------------------------------------------------
    RuleFor(User => User.cep).NotNull()
    .WithMessage("O cep deve ser preenchido.")
    .Length(8)
    .WithMessage("O cep deve ter 8 caracteres.");
    //--------------------------------------------------------------------------
    RuleFor(User => User.uf).NotEmpty()
    .WithMessage("O State deve ser preenchido.")
    .Length(2)
    .WithMessage("O State deve ter entre 2 caracteres.");
    //--------------------------------------------------------------------------
    RuleFor(User => User.city).NotEmpty()
    .WithMessage("O City deve ser preenchido.")
    .Length(5, 50)
    .WithMessage("A City deve ter entre 5 e 50 caracteres.");
    //--------------------------------------------------------------------------
    RuleFor(User => User.district).NotEmpty()
    .WithMessage("O District deve ser preenchido.")
    .Length(5, 60)
    .WithMessage("O District deve ter entre 5 e 60 caracteres.");
    //--------------------------------------------------------------------------
    RuleFor(User => User.street).NotEmpty()
    .WithMessage("O Street deve ser preenchido.")
    .Length(5, 70)
    .WithMessage("A Street deve ter entre 5 e 70 caracteres.");
  }
}