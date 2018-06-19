using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace UITests
{
    internal class HomePage
    {
        private BrowserWindow bw;

        public HomePage(BrowserWindow bw)
        {
            this.bw = bw;
        }

        internal bool PageHasProductsListed()
        {
            var productList = FindProductList();
            return productList.GetChildren().Count > 0;
        }

       

        internal ProductDetail ClickFirstProduct()
        {
            var productList = FindProductList();
            var hyperlink = FindHyperlinkForFirstProduct(productList);
            if (hyperlink != null)
                Mouse.Click(hyperlink);
            else
                throw new ArgumentException("Unable to find first product on homepage");

            return new ProductDetail(bw);
        }

        private HtmlHyperlink FindHyperlinkForFirstProduct(HtmlControl productList)
        {
            HtmlHyperlink hyperlink = new HtmlHyperlink(productList);
            var productHyperlinks = hyperlink.FindMatchingControls();
            if (productHyperlinks.Count > 0)
                return productHyperlinks[0] as HtmlHyperlink;
            else
                return null;
        }

        private HtmlControl FindProductList()
        {
            HtmlControl productList = new HtmlControl(bw);
            productList.SearchProperties.Add(HtmlControl.PropertyNames.Id, "album-list");
            return productList;
        }
    }
}