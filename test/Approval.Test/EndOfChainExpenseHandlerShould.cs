using System;
using Approval.Common;
using Xunit;

namespace Approval.Test
{
    // see example explanation on xUnit.net website:
    // https://xunit.github.io/docs/getting-started-dotnet-core.html
    public class EndOfChainExpenseHandlerShould
    {
        [Fact]
        public void CreateOnlySingleInstanceOfItsClass()
        {
            EndOfChainExpenseHandler instance1 = EndOfChainExpenseHandler.Instance;
            EndOfChainExpenseHandler instance2 = EndOfChainExpenseHandler.Instance;

            Assert.Same(instance1, instance2);
        }

        [Theory]
        [InlineData(50)]
        [InlineData(40000)]
        public void DenyAnyExpenseReport(decimal expenseAmount)
        {
            EndOfChainExpenseHandler handler = EndOfChainExpenseHandler.Instance;

            ApprovalResponse response = handler.Approve(new ExpenseReport(expenseAmount));

            Assert.Equal(ApprovalResponse.Denied, response);
        }

        [Fact]
        public void ThrowInvalidOperationExceptionOnRegisterNext()
        {
            EndOfChainExpenseHandler handler = EndOfChainExpenseHandler.Instance;

            Assert.Throws<InvalidOperationException>(() => handler.RegisterNext(new ExpenseHandler(new Employee("Tom", 500m))));
        }
    }
}
