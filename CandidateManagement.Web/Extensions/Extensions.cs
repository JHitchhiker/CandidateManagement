using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace CandidateManagement.Web.Extensions
{
    public static class Extensions
    {
        private const string asterisk = "<span class='style', style='color:Red;'> *</span>";

        public static MvcHtmlString Required<T, U>(this HtmlHelper<T> helper, Expression<Func<T, U>> expression, string text, bool forceRequired)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = !string.IsNullOrEmpty(text)
                ? text : metaData.DisplayName
                ?? metaData.PropertyName
                ?? htmlFieldName.Split('.').Last();

            var label = new TagBuilder("label");

            label.Attributes.Add("for"
                , helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));

            label.SetInnerText(labelText);
            if (metaData.IsRequired || forceRequired)
            {
                label.InnerHtml += asterisk;
            }
            return MvcHtmlString.Create(label.ToString());
        }

        public static List<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> enumerable, Func<T, string> getText, Func<T, string> getValue)
        {
            return enumerable.Select(x => new SelectListItem
            {
                Text = getText(x),
                Value = getValue(x)
            })
                             .ToList();
        }
    }
}