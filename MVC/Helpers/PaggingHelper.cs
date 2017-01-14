using System.Text;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using MVC.ViewModels.Pagging;

namespace MVC.Helpers
{
    public static class PaggingHelper
    {
        public static MvcHtmlString Page(this AjaxHelper ajax,
        PageInfo pageInfo, string updateTargetId, Func<int, string> pageUrl, string loadingId = "loading", string duration = "1000")
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder link = new TagBuilder("a");
                string u = pageUrl(i);
                link.MergeAttribute("href", u);
                link.MergeAttribute("data-ajax", "true");
                link.MergeAttribute("data-ajax-mode", "replace");
                link.MergeAttribute("data-ajax-update", $"#{updateTargetId}");
                link.MergeAttribute("data-ajax-loading", $"#{loadingId}");
                link.MergeAttribute("data-ajax-loading-duration", duration);
                link.MergeAttribute("class", i == pageInfo.PageNumber ? "btn btn-primary selected" : "btn btn-default");
        
                link.InnerHtml = i.ToString();
                result.Append(link);

            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}