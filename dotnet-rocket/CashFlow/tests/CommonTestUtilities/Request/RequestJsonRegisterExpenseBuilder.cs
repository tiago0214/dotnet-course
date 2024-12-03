using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Request;

namespace CommonTestUtilities.Request;

public class RequestJsonRegisterExpenseBuilder
{
    public static RequestJsonRegisterExpense build()
    {
        return new Faker<RequestJsonRegisterExpense>()
            .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
            .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 1000))
            .RuleFor(r => r.Date, faker => faker.Date.Past())
            .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
            .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription());
    }
}
