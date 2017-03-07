using System;
using Approval.Common;
using Xunit;

namespace Approval.Test
{
    // see example explanation on xUnit.net website:
    // https://xunit.github.io/docs/getting-started-dotnet-core.html
    public class ExpenseHandlerShould
    {
        [Fact]
        public void ApproveExpenseWithInstanceExpenseApprover()
        {
            ExpenseHandler mary = new ExpenseHandler(new Employee("Mary Manager", new Decimal(1000)));
            ApprovalResponse response = mary.Approve(new ExpenseReport(500));

            Assert.Equal(ApprovalResponse.Approved, response);
        }

        [Fact]
        public void ApproveExpenseWithInstanceNextExpenseHandler()
        {
            ExpenseHandler mary = new ExpenseHandler(new Employee("Mary Manager", new Decimal(1000)));
            ExpenseHandler victor = new ExpenseHandler(new Employee("Victor Vicepres", new Decimal(5000)));

            mary.RegisterNext(victor);

            ApprovalResponse response = mary.Approve(new ExpenseReport(1500));

            Assert.Equal(ApprovalResponse.Approved, response);
        }

        [Fact]
        public void DeclineExpenseForAmountThatNoExpenseHandlerCanApprove()
        {
            ExpenseHandler mary = new ExpenseHandler(new Employee("Mary Manager", new Decimal(1000)));
            ExpenseHandler victor = new ExpenseHandler(new Employee("Victor Vicepres", new Decimal(5000)));

            mary.RegisterNext(victor);

            ApprovalResponse response = mary.Approve(new ExpenseReport(15000));

            Assert.Equal(ApprovalResponse.Denied, response);
        }
    }
}
