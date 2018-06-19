using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace UITests
{
    internal class ShoppingCart
    {
        private BrowserWindow bw;

        public ShoppingCart(BrowserWindow bw)
        {
            this.bw = bw;
        }

        internal Login Checkout()
        {
            var checkoutButton = FindHyperlink();


            Mouse.Click(checkoutButton);
            return new Login(bw);

        }

        private HtmlHyperlink FindHyperlink()
        {
            HtmlHyperlink link = new HtmlHyperlink(bw);
            link.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, "Checkout >>", PropertyExpressionOperator.Contains);
            return link;
        }
    }
}