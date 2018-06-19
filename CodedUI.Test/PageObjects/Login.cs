using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace UITests
{
    internal class Login
    {
        private BrowserWindow bw;

        public Login(BrowserWindow bw)
        {
            this.bw = bw;
        }
        internal bool IsCheckoutPageValid()
        {
            HtmlInputButton btn = new HtmlInputButton(bw);
            btn.SearchProperties.Add(HtmlControl.PropertyNames.ValueAttribute, "Log On", PropertyExpressionOperator.Contains);
            return btn.TryFind();
        }
    }
}