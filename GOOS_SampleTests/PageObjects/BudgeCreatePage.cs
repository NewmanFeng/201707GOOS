using System.Web.Instrumentation;
using FluentAutomation;

namespace GOOS_SampleTests.PageObjects
{
    public class BudgetCreatePage:PageObject<BudgetCreatePage>
    {
        public BudgetCreatePage(FluentTest fluentTest)
            : base(fluentTest)
        {

            this.Url = PageContext.Domain + "/budget/add";
        }

        public BudgetCreatePage Amount(int amount)
        {

            I.Enter(amount.ToString()).In("#amount");
            return this;
        }

        public BudgetCreatePage Month(string yearMonth)
        {
            I.Enter(yearMonth).In("#month");
            return this;
        }

        public void AddBudget()
        {
            I.Click("input[type=\"submit\"]");
        }

        public void ShouldDisplay(string message)
        {
            I.Assert.Text(message).In("#message");
        }
    }

    public class PageContext
    {
        public static string Domain {
            get { return "http://localhost:58527"; }
        }
    }
}
