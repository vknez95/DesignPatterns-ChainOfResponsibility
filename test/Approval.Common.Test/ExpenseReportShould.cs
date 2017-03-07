using Xunit;

namespace Approval.Common.Test
{
    // see example explanation on xUnit.net website:
    // https://xunit.github.io/docs/getting-started-dotnet-core.html
    public class ExpenseReportShould
    {
        private ExpenseReport report = new ExpenseReport(1000);

        [Fact]
        public void RetrieveExpenseAmount()
        {
            Assert.Equal(1000, report.Total);
        }
    }
}
