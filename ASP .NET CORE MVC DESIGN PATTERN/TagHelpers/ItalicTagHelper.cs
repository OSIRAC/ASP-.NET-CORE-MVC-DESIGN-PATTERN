using Microsoft.AspNetCore.Razor.TagHelpers;

namespace EFCORE_VERİALMA.TagHelpers
{
    [HtmlTargetElement("italic")] //CUSTOM BİR ŞEKİLDE İSMİNİ VERDİK
    public class ItalicTagHelper : TagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //CONTEXT YAZILMIŞ TAGIN ÖZELLİKLERİNE BAKMAMIZA SAĞLAR İŞLEMEMİZİ SAĞLAR
            //OUTPUT MODİFİYE ETMEMİZE OLUŞTURMAMIZA OLANAK SAĞLAR YENİ BAŞTAN TAG OLUŞTURUYORSAK CONTEXT GENELDE GEREK YOKTUR

            output.PreContent.SetHtmlContent("<i>");
            output.PostContent.SetHtmlContent("</i>");

        }
    }
}
