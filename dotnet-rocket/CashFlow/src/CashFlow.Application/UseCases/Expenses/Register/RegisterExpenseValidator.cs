using CashFlow.Communication.Enums;
using CashFlow.Communication.Request;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseValidator : AbstractValidator<RequestJsonRegisterExpense>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("The title is required.");
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date can't be set in the future");
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("Payment method is invalid.");
    }
}
