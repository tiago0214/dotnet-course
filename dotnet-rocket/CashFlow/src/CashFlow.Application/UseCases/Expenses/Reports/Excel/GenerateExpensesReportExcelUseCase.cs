using CashFlow.Domain.Enums;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Reports.Excel;

public class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase
{
    private const string CURRENCY_SYMBOL = "R$";

    private readonly IExpensesReadOnlyRepository _repository;

    public GenerateExpensesReportExcelUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<byte[]> Execute(DateOnly month)
    {
        var expenses = await _repository.FilterByMonth(month);

        if (expenses.Count == 0)
            return new byte[0];

        using var workbook = new XLWorkbook();

        workbook.Author = "Tiago";
        workbook.Style.Font.FontSize = 12;
        workbook.Style.Font.FontName = "Times New Roman";

        var worksheet = workbook.Worksheets.Add(month.ToString("Y"));

        InsertHeader(worksheet);

        var rows = 2;

        foreach (var expense in expenses) 
        {
            worksheet.Cell($"A{rows}").Value = expense.Title;
            worksheet.Cell($"B{rows}").Value = expense.Date;
            worksheet.Cell($"C{rows}").Value = ConvertPaymentType(expense.PaymentType);
            
            worksheet.Cell($"D{rows}").Value = expense.Amount;
            worksheet.Cell($"D{rows}").Style.NumberFormat.Format = $"-{CURRENCY_SYMBOL} #,##0.00";

            worksheet.Cell($"E{rows}").Value = expense.Description;

            rows++;
        }

        worksheet.Columns().AdjustToContents();

        var file = new MemoryStream();

        workbook.SaveAs(file);

        return file.ToArray();
    }

    private string ConvertPaymentType(PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.Cash => "Dinheiro",
            PaymentType.CreditCard => "Cartão de crédito",
            PaymentType.EletronicTransfer => "Transferência eletrônica",
            PaymentType.DebitCard => "Cartão de débito",
            _ => string.Empty
        };
    }

    private void InsertHeader (IXLWorksheet worksheet)
    {
        worksheet.Cell("A1").Value  = ResourceReportGenerationMessages.TITLE;
        worksheet.Cell("B1").Value  = ResourceReportGenerationMessages.DATE;
        worksheet.Cell("C1").Value  = ResourceReportGenerationMessages.PAYMENT_TYPE;
        worksheet.Cell("D1").Value  = ResourceReportGenerationMessages.AMOUNT;
        worksheet.Cell("E1").Value  = ResourceReportGenerationMessages.DESCRIPTION;

        worksheet.Cells("A1:E1").Style.Font.Bold = true;

        worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#f5c3b8");

        worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
    }
}
