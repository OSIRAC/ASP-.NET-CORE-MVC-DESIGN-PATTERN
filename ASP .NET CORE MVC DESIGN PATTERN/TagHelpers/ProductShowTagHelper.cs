using EFCORE_VERİALMA.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Reflection.Metadata.Ecma335;

namespace EFCORE_VERİALMA.TagHelpers
{
    public class ProductShowTagHelper : TagHelper
    {

        public Product Product { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div"; //@ İŞARETİ ALT ALTA STRİNG YAZABİLİRİZ TagName <div></div> yapar
                                    //output.content DİVİN İÇİNE GİRER HTMLCONTENT DE HTML YERLEŞTİRİRİZ
            output.Content.SetHtmlContent(@$"<ul class='list-group'>  
                        <li class='list-group-item'>{Product.Id}</li>)
                        <li class='list-group-item'>{Product.Name}</li>
                        <li class='list-group-item'>{Product.Price}</li>
                        <li class='list-group-item'>{Product.Stock}</li>
                        </ul>");
        }
    }
}
