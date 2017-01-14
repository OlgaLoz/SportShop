using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MVC.ViewModels.Pagging;

namespace MVC.Helpers
{
    public static class ImageHelper
    {
        public static MvcHtmlString Image(this HtmlHelper html, string src, string alt, string height, string width)
        {
            TagBuilder tagBuilder = new TagBuilder("img");
            tagBuilder.MergeAttribute("src", src);
            tagBuilder.MergeAttribute("alt", alt);
            tagBuilder.MergeAttribute("height", height);
            tagBuilder.MergeAttribute("width", width);

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.SelfClosing));

        }
    }
}