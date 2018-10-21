using AudenAutomation.Driver;
using AudenAutomation.Pages.PageItems;
using Coypu;
using System;
using System.Globalization;
using System.Linq;

namespace AudenAutomation.Pages

{
    public class BasePage
    {

        public BasePage() { }

        public virtual Scope root {
            get { return BrowserDriver.Instance; }
            protected set { }
        }
        
        private Form form;

        public void Goto(string url)
        {
            BrowserDriver.Instance.Visit(url);
        }

        public string PageTitle
        {
            get { return BrowserDriver.Instance.Title.ToString(); }
        }

        public void ClickButton(string button)
        {
            root.ClickButton(button, new Options { Timeout = TimeSpan.FromSeconds(3) } );
        }

        public void ClickLink(string link)
        {
            root.ClickLink(link);
        }

        public void SelectOptionFromDropDown(string option, string dropDown)
        {
            //Sort by dropdown doesn't work with built in finder
            //need the select starting with uniform-

            //get the id from the label "for" tag
            var _ddId =
                  root.FindCss("label", text: dropDown)["for"];
            //drop down id ends with the relevant id
            var _dropDown = root.FindIdEndingWith(_ddId);

            //find all options, then filter to the first with matching text and click
            var _options = _dropDown.FindAllCss("option").Where(
                element => element.Text == option)
                .First()
                .Check();
        }

        public void FillInEditBoxWithContent(string editbox, string content)
        {
            var a = root.FillIn("First name");
            root.FillIn(editbox,new Options { Timeout = TimeSpan.FromSeconds(5), Match = Match.First }).With(content);
        }

        public void ChooseRadioButtonFromOptions(string radioButton, string options)
        {
            ElementScope _root = root.FindAllCss("div")
                .Where(e => e.FindCss("label", text: options).Exists()).First();
            var _rbId = _root.FindCss("label", text: radioButton)["for"];
            root.FindIdEndingWith(_rbId).Check();
        }

        public void SetDatePicker(string label, string date)
        {
            DateTime _date = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            ElementScope _root = root.FindCss("div.form-group", text: label);

            _root.FindId("uniform-days").FindAllCss("option")
                .Where(option => option.Value == _date.Day.ToString()).First().Check();
            _root.FindId("uniform-months").FindAllCss("option")
                .Where(option => option.Value == _date.Month.ToString()).First().Check();
            _root.FindId("uniform-years").FindAllCss("option")
                .Where(option => option.Value == _date.Year.ToString()).First().Check();

        }

        public void ClickCheckBox(string checkbox)
        {
            var _cbId =
                root.FindCss("label",text: checkbox)["for"];
            root.FindIdEndingWith(_cbId).Check();
        }

        public void WaitForContent(string content)
        {
            root.HasContent(content, new Options { Timeout = TimeSpan.FromSeconds(5) });
        }

        public void LogOut()
        {
            root.FindCss("a[class=logout").Click();
        }

        public bool IsLoggedIn()
        {
            return root.FindCss("a[class=logout").Exists();
                
        }

        public Form Form (string formName)
        {
            var baseElement = root.FindAllCss("Form").Where(
                element => element.FindCss("h3", text: formName.ToUpper())
                .Exists())
                .First();
            if (form == null || baseElement.Id != form.Id ) {
                form = new Form(baseElement); }
            return form;
            
        }
    }
}
