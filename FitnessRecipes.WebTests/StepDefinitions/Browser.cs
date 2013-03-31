using System;
using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.WebTests.Helpers;
using WatiN.Core;

namespace FitnessRecipes.WebTests.StepDefinitions
{
    class Browser
    {
        private static string _rootUrl = "http://localhost:19081/";
        private static IE _browser;

        public static IE Instance
        {
            get { return _browser ?? (_browser = new IE { AutoClose = true }); }
        }

        public static void NavigateTo(string url)
        {
            url = _rootUrl + url;
            Instance.GoTo(url);
            Update();
        }

        public static void Update()
        {
            Instance.Refresh();
        }

        public static void ShowStartPage()
        {
            NavigateTo(_rootUrl);
        }

        public static void Close()
        {
            if (Instance == null) return;
            Instance.ForceClose();
        }

        public static bool HasTextFieldWithValue(string textFieldId, string text)
        {
            var textField = Instance.TextField(Find.ById(textFieldId));
            if (textField.Exists)
            {
                if (textField.Value != null)
                    return textField.Value.Equals(text);
                return text == string.Empty;

            }
            return false;
        }

        public static bool HasTextFieldByNameWithValue(string textFieldName, string text)
        {
            var textField = Instance.TextField(Find.ByName(textFieldName));
            if (textField.Exists)
            {
                if (textField.Value != null)
                    return textField.Value.Equals(text);
                return text == string.Empty;

            }
            return false;
        }

        public static bool HasElementWithValue(string elementId, string text)
        {
            var element = Instance.Element(Find.ById(elementId));
            if (element.Exists)
            {
                if (element.Text != null)
                    return element.Text.Equals(text);
                return text == string.Empty;

            }
            return false;
        }

        public static bool HasButtonWithValue(string elementId, string text)
        {
            var element = Instance.Button(Find.ById(elementId));
            if (element.Exists)
            {
                if (element.Text != null)
                    return element.Text.Equals(text);
                return text == string.Empty;

            }
            return false;
        }

        public static void TrykkPåLink(string lenkeTekstEllerId)
        {
            if (HarElementMedId<Link>(lenkeTekstEllerId))
                ElementMedId<Link>(lenkeTekstEllerId).Click();
            else
                ElementMedTekst<Link>(lenkeTekstEllerId).Click();
        }

        public static void KlikkLink(string id)
        {
            Instance.Link(id).Click();
        }

        private static bool HarElementMedId<TElement>(string id) where TElement : Element
        {
            try
            {
                return ElementMedId<TElement>(id).Exists;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static TElement ElementMedId<TElement>(string id) where TElement : Element
        {
            return (TElement)Instance.Element(id);
            //            return Instance.ElementOfType<TElement>(Find.ById(id));
        }


        private static TElement ElementMedTekst<TElement>(string tekst) where TElement : Element
        {
            return ElementerMedTekst<TElement>(tekst).First();
        }

        private static List<TElement> ElementerMedTekst<TElement>(string tekst) where TElement : Element
        {
            var elementList = Instance.Elements.Where(e =>
            {
                if (!string.IsNullOrEmpty(e.Text))
                {
                    return e.Text.Contains(tekst);
                }

                if (!string.IsNullOrEmpty(e.InnerHtml))
                {
                    return e.InnerHtml.Contains(tekst);
                }
                return false;
            }).ToList();

            return elementList.Cast<TElement>().ToList();

        }

        public static void SetVerdiINedtrekksliste(string id, string verdi)
        {
            var ddl = Instance.SelectList(Find.ById(id));
            if (ddl.Exists)
            {
                ddl.SelectByValue(verdi);
                ddl.ForceChange();
                ddl.WaitForComplete();
            }
        }

        public static void SelectItemInDropdownByName(string id, string name)
        {
            var ddl = Instance.SelectList(Find.ById(id));
            if (ddl.Exists)
            {
                ddl.Select(name);
                ddl.ForceChange();
                ddl.WaitForComplete();
            }
        }

        public static bool ErStartet()
        {
            return true;
        }

        public static void SetVerdiIRadioknappliste(string radiobuttonlistid, bool velg)
        {
            var rbl = Instance.RadioButton(Find.ById(radiobuttonlistid));
            if (rbl.Exists)
            {
                rbl.Checked = velg;
            }
        }

        public static bool ViserTabell(string tabellid)
        {
            var tb = Instance.Table(tabellid);
            return tb.Exists;
        }

        public static void KlikkKPåKnapp(string knappid)
        {
            var knapp = Instance.Button(Find.ById(knappid));
            knapp.Click();
        }

        public static void ClickButtonWithValue(string buttonValue)
        {
            var button = Instance.Button(Find.ByValue(buttonValue));
            button.Click();
        }

        public static bool HarTekstfelt(string tekst)
        {
            return Instance.Spans.Exists(label => label.Text.Equals(tekst));
        }

        public static void HukAvKryssboks(string kryssboksid, bool hukav)
        {
            var kryssboks = Instance.CheckBox(Find.ById(kryssboksid));
            kryssboks.Checked = hukav;
        }

        public static void VelgRadioknapp(string radioknappid, bool hukav)
        {
            var radioknapp = Instance.RadioButton(Find.ById(radioknappid));
            radioknapp.Checked = hukav;
        }


        public static bool ViserFeilmelding(string feilmeldingsklasse)
        {
            return Instance.Div(Find.ByClass(feilmeldingsklasse)).Exists;
        }


        public static int HentNedtrekkslisteAntall(string id)
        {
            var ddl = Instance.SelectList(Find.ById(id));
            if (ddl.Exists)
                return ddl.Options.Count;
            return 0;
        }

        public static bool DivWithIdIsShown(string id)
        {
            var div = Instance.Div(Find.ById(id));
            if (div.Exists)
            {
                if (div.GetAttributeValue("style") != null)
                {
                    if (div.GetAttributeValue("style").Contains("display: none") || div.GetAttributeValue("style").Contains("display:none"))
                        return false;
                    else
                        return true;
                }
                return true;
            }
            return false;
        }

        public static bool DivWithClassIsShown(string classid)
        {
            var div = Instance.Div(Find.ByClass(classid));
            if (div.Exists)
            {
                if (div.GetAttributeValue("style") != null)
                {
                    if (div.GetAttributeValue("style").Contains("display: none") || div.GetAttributeValue("style").Contains("display:none"))
                        return false;
                    else
                        return true;
                }
                return true;
            }
            return false;
        }

        public static void SetTextboxValue(string id, string value)
        {
            var textbox = Instance.ElementOfType<TextFieldExtended>(Find.ById(id));

            if (textbox.Exists)
            {
                textbox.Value = value;
                textbox.ForceChange();
                textbox.WaitForComplete();
            }
        }

        public static void SetTextboxByNameValue(string name, string value)
        {
            var textbox = Instance.ElementOfType<TextFieldExtended>(Find.ByName(name));

            if (textbox.Exists)
            {
                textbox.Value = value;
            }
        }


        public static void SetVerdiInput(string id, string verdi)
        {
            var input = Instance.FileUpload(Find.ById(id));
            if (input.Exists)
            {
                input.Set(verdi);
            }
        }

        internal static bool IsAtPage(string url)
        {
            return Instance.Url.Contains(_rootUrl + url);
        }

        public static void KlikkSpan(string klasse)
        {
            var span = Instance.Span(Find.ByClass(klasse));
            if (span.Exists)
            {
                span.Click();
            }
        }

        internal static bool SpanWithClassIsShown(string classid)
        {
            var span = Instance.Span(Find.ByClass(classid));
            if (span.Exists)
            {
                if (span.GetAttributeValue("style") != null)
                {
                    if (span.GetAttributeValue("style").Contains("display: none") || span.GetAttributeValue("style").Contains("display:none"))
                        return false;
                    else
                        return true;
                }
                return true;
            }
            return false;
        }

        public static void SetElementValue(string fieldId, string text)
        {
            var element = Instance.Element(Find.ById(fieldId));
            if (element.Exists)
            {
                element.SetAttributeValue("value", text);
            }
        }

        public static void LogOut()
        {
            var link1 = Instance.Link(Find.ByText("Logg ut"));
            //link1.WaitUntilExists();
            if (link1.Exists)
                link1.Click();
        }

        public static bool ButtonIsEnabled(string buttonId)
        {
            var button = Instance.ElementOfType<Button>(Find.ById(buttonId));
            return button.Enabled;
        }

        public static void ClickLinkWithId(string linkId)
        {
            var link = Instance.ElementOfType<Link>(Find.ById(linkId));
            if(link.Exists)
                link.Click();
        }

        public static void SelectFirstValueInDropDown(string ddlId)
        {
            throw new NotImplementedException();
        }
    }
}
