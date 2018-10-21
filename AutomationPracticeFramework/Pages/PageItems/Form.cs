using Coypu;

namespace AudenAutomation.Pages.PageItems

{
    public class Form : BasePage
    {
        public virtual string Id { get; protected set; }
        public override Scope root { get; protected set; }
        public Form(ElementScope scope)
        {
            root = scope;
            Id = scope.Id;
        }
    }
}
