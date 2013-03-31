using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace FitnessRecipes.Helpers
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString LabelForRequired<TModel, TValue>(this HtmlHelper<TModel> html,
                                             Expression<Func<TModel, TValue>> expression,
                                             string labelText, string classname)
        {
            return LabelHelper(html,
                               ModelMetadata.FromLambdaExpression(expression, html.ViewData),
                               ExpressionHelper.GetExpressionText(expression), labelText, classname);
        }

        public static MvcHtmlString LabelForRequired<TModel, TValue>(this HtmlHelper<TModel> html,
                                                     Expression<Func<TModel, TValue>> expression,
                                                     string labelText, IDictionary<string, object> moreAttributes)
        {
            return LabelHelper(html,
                               ModelMetadata.FromLambdaExpression(expression, html.ViewData),
                               ExpressionHelper.GetExpressionText(expression), labelText, moreAttributes.First().Value.ToString());
        }

        public static MvcHtmlString LabelForRequired<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                     Expression<Func<TModel, TValue>> expression,
                                                                     string labelText = "")
        {
            return LabelHelper(html,
                               ModelMetadata.FromLambdaExpression(expression, html.ViewData),
                               ExpressionHelper.GetExpressionText(expression), labelText, "");
        }

        private static MvcHtmlString LabelHelper(HtmlHelper html, ModelMetadata metadata, string htmlFieldName, string labelText, string classname)
        {
            if (string.IsNullOrEmpty(labelText))
            {
                labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            }

            if (string.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            bool isRequired = false;
            if (metadata.ContainerType != null)
            {
                isRequired = metadata.ContainerType.GetProperty(metadata.PropertyName)
                                 .GetCustomAttributes(typeof(RequiredAttribute), false)
                                 .Length == 1;
            }

            TagBuilder tag = new TagBuilder("label");
            tag.Attributes.Add(
                "for",
                TagBuilder.CreateSanitizedId(
                    html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)
                    )
                );

            if (isRequired)
                tag.Attributes.Add("class", classname != "" ? String.Format("label-required {0}", classname) : "label-required");
            else if (!string.IsNullOrEmpty(classname))
            {
                tag.Attributes.Add("class", classname);
            }
            tag.SetInnerText(labelText);
            var output = tag.ToString(TagRenderMode.Normal);

            if (isRequired)
            {
                var asteriskTag = new TagBuilder("span");
                asteriskTag.Attributes.Add("class", "required");
                asteriskTag.SetInnerText("*");
                output += asteriskTag.ToString(TagRenderMode.Normal);
            }
            return MvcHtmlString.Create(output);
        }
    }
}