
using CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Fonts;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf;

public class GenerateExpensesReportPdfUseCase : IGenerateExpensesReportPdfUseCase
{
    private const string CURRENCY_SYMBOL = "R$";
    private readonly IExpensesReadOnlyRepository _repository;

    public GenerateExpensesReportPdfUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;

        GlobalFontSettings.FontResolver = new ExpensesReportFontResolver();
    }

    public async Task<byte[]> Execute(DateOnly date)
    {
        var expenses = await _repository.FilterByMonth(date);

        if (expenses.Count == 0)
            return new byte[0];

        var document = CreateDocument(date);
        var page = CreatePage(document);

        return new byte[0]; 
    }

    private Document CreateDocument(DateOnly date)
    {
        var document = new Document();

        document.Info.Title = $"{ResourceReportGenerationMessages.EXPENSES_FOR} {date.ToString("Y")}";
        document.Info.Author = "Tiago Souza";

        var style = document.Styles["Normal"];
        style!.Font.Name = FontHelper.RALEWAY_REGULAR;

        return document;
    }

    private Section CreatePage(Document document) 
    {
        var section = document.AddSection();

        section.PageSetup = document.DefaultPageSetup.Clone();

        section.PageSetup.PageFormat = PageFormat.A4;

        section.PageSetup.LeftMargin = 40;
        section.PageSetup.RightMargin = 40;
        section.PageSetup.TopMargin = 80;
        section.PageSetup.BottomMargin = 80;

        return section;
    }
}
