using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CommonTestUtilities.Request;
using FluentAssertions;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Sucess()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestJsonRegisterExpenseBuilder.build();

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("         ")]
    [InlineData(null)]
    public void ErrorTitleEmpty(string title)
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestJsonRegisterExpenseBuilder.build();
        request.Title = title;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_ERROR));
    }

    [Fact]
    public void ErrorDateFuture()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestJsonRegisterExpenseBuilder.build();
        request.Date = DateTime.UtcNow.AddDays(1);

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.DATE_ERROR));
    }

    [Fact]
    public void ErrorInvalidPaymentType()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestJsonRegisterExpenseBuilder.build();
        request.PaymentType = (PaymentType)700;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain( e => e.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_ERROR));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(-3)]
    [InlineData(-7)]
    public void ErrorAmountInvalid(decimal amount)
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestJsonRegisterExpenseBuilder.build();
        request.Amount = amount;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_ERROR));
    }
}
