using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DrTaabodi.Data.ExtraCode;

[HtmlTargetElement("div", Attributes = "filesystem")]
public class FileSystemTagHelper : TagHelper
{
    [HtmlAttributeName("filesystem")] public string Id { get; set; }

    [HtmlAttributeName("filesystem-full-name")]
    public string FullName { get; set; }

    [HtmlAttributeName("filesystem-full-height")]
    public int? Height { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var height = Height ?? 400;
        output.Attributes.Add("style", $"overflow-y:auto;overflow-x:hidden;height:{height}px");

        var fullName = FullName ?? "";
        fullName = fullName.Replace(@"\", @"\\");

        var sb = new StringBuilder();
        sb.Append($"<div id=\"{Id}0\"></div>");
        sb.Append("<script type=\"text/javascript\">");
        sb.Append("$(document).ready(function () {");
        sb.Append($"fileSystem.build('{fullName}', '{Id}', 0, 0);");
        sb.Append("});");
        sb.Append("</script>");

        output.Content.SetHtmlContent(sb.ToString());
    }
}