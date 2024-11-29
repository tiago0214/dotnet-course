using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Request;
using CashFlow.Communication.Enums;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Sucess()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = new RequestJsonRegisterExpense()
        {
            Amount = 100,
            Date = DateTime.Now.AddDays(-1),
            Description = "Whatever",
            Title = "Some title",
            PaymentType = PaymentType.CreditCard
        };
        //Act
        var result = validator.Validate(request);

        //Assert
        Assert.True(result.IsValid);
    }
}
