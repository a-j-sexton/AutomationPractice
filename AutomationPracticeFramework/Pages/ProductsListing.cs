using AudenAutomation.Driver;
using AudenAutomation.Pages.PageItems;
using System.Collections.Generic;
using System.Linq;
using Coypu;


namespace AudenAutomation.Pages
{
    public  class ProductsListing : BasePage
    {
        public override Coypu.Scope root { get; protected set; }

        public ProductsListing()
        {
            root = BrowserDriver.Instance.FindCss("ul.product_list.grid.row");
        }

        public Form ProductByPrice(string price)
        {
            ElementScope _scope = ProductsList.Where(
                element => element.FindCss("span.price", text: price)
                .Exists())
                .First();

            if (Product == null || Product.GetHashCode() != _scope.GetHashCode())
            {
                Product = new Product(_scope);
            }

            return Product;
        }

        public Product ProductByIndex(int index)
        {
            ElementScope _scope = ProductsList.ToList()[index];
            if (Product == null || Product.Id != _scope.Id)
            {
                Product = new Product(ProductsList.ToList()[index]);
            }

            return Product;
        }

        public IEnumerable<SnapshotElementScope> ProductsList
        {
            get { return root.FindAllCss("li"); }
        }

        private Product Product
        {
            get;
            set;
        }
    }
}
