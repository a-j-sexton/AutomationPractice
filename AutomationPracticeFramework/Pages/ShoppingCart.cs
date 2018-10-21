using AudenAutomation.Driver;
using Coypu;
using System;
using System.Collections.Generic;
using System.Linq;
using AudenAutomation.Pages.PageItems;

namespace AudenAutomation.Pages
{
    public class ShoppingCart : BasePage
    {
        public override Scope root { get; protected set; }
        public ShoppingCart()
        {
            var _root = BrowserDriver.Instance.FindId("cart_summary");
            if(_root.Exists())
            {
                root = _root;
                return;
            }
            root = null;
        }

        public Product ProductByIndex(int index)
        {
            if (ProductsList != null)
            {
                ElementScope _scope = ProductsList.ToList()[index];
                if (Product == null || Product.Id != _scope.Id)
                {
                    Product = new Product(ProductsList.ToList()[index]);
                }

                return Product;
            }

            throw new Exception("FATAL: There are no products in the ShoppingCart!");
        }

        public Product ProductByPrice(string price)
        {
            if (ProductsList != null)
            {
                ElementScope _scope = ProductsList.Where(
                    element => element.FindCss("span.price", text: price)
                    .Exists())
                    .First();

                if (Product == null || Product.Id != _scope.Id)
                {
                    Product = new Product(_scope);
                }

                return Product;
            }

            return null;
        }

        public IEnumerable<SnapshotElementScope> ProductsList
        {
            get
            {
                if(root != null) {return root.FindCss("tbody").FindAllCss("tr"); }
                return null;
            }
        }

        private Product Product
        {
            get;
            set;
        }

    }
}
