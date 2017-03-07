using Xunit;

namespace Approval.Common.Test
{
    // see example explanation on xUnit.net website:
    // https://xunit.github.io/docs/getting-started-dotnet-core.html
    public class EmployeeShould
    {
        [Fact]
        public void ApproveExpenseReportIfExpenseAmountIsLessThanApprovalLimit()
        {
            Employee employee = new Employee("Tom", 1000m);

            ExpenseReport report = new ExpenseReport(500);

            ApprovalResponse response = employee.ApproveExpense(report);

            Assert.Equal(ApprovalResponse.Approved, response);
        }

        [Fact]
        public void DeclineExpenseReportWithBeyondApprovalLimitIfExpenseAmountIsGreaterThanApprovalLimit()
        {
            Employee employee = new Employee("Tom", 1000m);

            ExpenseReport report = new ExpenseReport(1500);

            ApprovalResponse response = employee.ApproveExpense(report);

            Assert.Equal(ApprovalResponse.BeyondApprovalLimit, response);
        }
    }
}
