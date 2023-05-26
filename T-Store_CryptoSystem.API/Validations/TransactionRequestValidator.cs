using FluentValidation;
using T_Store_CryptoSystem.API.Infrastructure;
using T_Store_CryptoSystem.API.Models.Request;

namespace T_Store_CryptoSystem.API.Validations;

public class TransactionRequestValidator : AbstractValidator<TransactionRequest>
{
    public TransactionRequestValidator()
    {
        RuleFor(t => t.Currency)
            .IsInEnum().WithMessage(ApiErrorMessage.CurrencyRangeError);
        RuleFor(t => t.AccountId)
            .GreaterThanOrEqualTo(1).WithMessage(ApiErrorMessage.NumberLessOrEqualZero);
        RuleFor(t => t.Amount)
            .GreaterThanOrEqualTo(1).WithMessage(ApiErrorMessage.NumberLessOrEqualZero);
    }
}
