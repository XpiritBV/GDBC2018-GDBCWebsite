using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace UITests
{
    internal class ProductDetail
    {
        private BrowserWindow bw;

        public ProductDetail(BrowserWindow bw)
        {
            this.bw = bw;
        }

        internal ShoppingCart AddToChart()
        {
            var AddToChartHyperlink = FindHyperlink();
            Mouse.Click(AddToChartHyperlink);
            return new ShoppingCart(bw);
        }

        private HtmlHyperlink FindHyperlink()
        {
            HtmlHyperlink link = new HtmlHyperlink(bw);
            link.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, "Add to cart", PropertyExpressionOperator.Contains);
            return link;
        }
    }
}