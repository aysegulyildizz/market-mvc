using Microsoft.AspNetCore.Razor.TagHelpers;
using mvc.Models;

namespace mvc.TagHelpers
{
    [HtmlTargetElement("stok-durumu", Attributes = "product")]
    public class StokDurumuTagHelper : TagHelper
    {
        public Product? Product { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span"; // <stok-durumu> yerine <span> render edilir
            output.TagMode = TagMode.StartTagAndEndTag;

            if (Product == null)
            {
                output.Content.SetContent(" No product information . ");
                return;
            }

            if (Product.Stock > 0)
            {
                output.Content.SetContent($" In stoc : {Product.Stock} ");
                output.Attributes.SetAttribute("style", "color: green; font-weight: bold;");
            }
            else
            {
                output.Content.SetContent(" No Stoc");
                output.Attributes.SetAttribute("style", "color: red; font-weight: bold;");
            }
        }
    }
}