using Coypu;

namespace AudenAutomation.Pages.PageItems
{
    public class Product : Form
    {
        public override string Id { get;  protected set; }
        public override Scope root { get; protected set; }
        public Product(ElementScope scope) : base(scope)
        {
            root = scope;
            Id = scope.Id; 
        }

        public string Price
        {
            get
            {
                if (root != null)
                {
                    string _price = root.FindCss("span.price",
                           new Options { Match = Match.First }).Text;
                    if(_price != null)
                    {
                        return _price;
                    }
                    return "ERROR: No price element found!";
                }
                return "ERROR: No Product Found!";
            }
        }   
    }
}
