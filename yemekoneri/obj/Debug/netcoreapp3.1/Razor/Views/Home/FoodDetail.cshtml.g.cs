#pragma checksum "F:\User\Desktop\test apps\yemekoneri\yemekoneri\yemekoneri\yemekoneri\Views\Home\FoodDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94dd3710454f5d01987b3e1cac65aee60b5bac3c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FoodDetail), @"mvc.1.0.view", @"/Views/Home/FoodDetail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\User\Desktop\test apps\yemekoneri\yemekoneri\yemekoneri\yemekoneri\Views\_ViewImports.cshtml"
using yemekoneri;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\User\Desktop\test apps\yemekoneri\yemekoneri\yemekoneri\yemekoneri\Views\_ViewImports.cshtml"
using yemekoneri.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94dd3710454f5d01987b3e1cac65aee60b5bac3c", @"/Views/Home/FoodDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae836ac3f9355f019218c150e1abf2b4063dcb2d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FoodDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<yemekoneri.Entities.Yemek>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/foodDetail.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\User\Desktop\test apps\yemekoneri\yemekoneri\yemekoneri\yemekoneri\Views\Home\FoodDetail.cshtml"
  
    ViewData["Title"] = "FoodDetail";
    Layout = "~/Views/Shared/_UserLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <input type=\"hidden\" name=\"yemekId\" id=\"yemekId\"");
            BeginWriteAttribute("value", " value=\"", 187, "\"", 209, 1);
#nullable restore
#line 8 "F:\User\Desktop\test apps\yemekoneri\yemekoneri\yemekoneri\yemekoneri\Views\Home\FoodDetail.cshtml"
WriteAttributeValue("", 195, Model.YemekId, 195, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<div class=\"container mt-5\" id=\"topContainer\">\r\n    <div class=\"row\">\r\n        <h3>");
#nullable restore
#line 11 "F:\User\Desktop\test apps\yemekoneri\yemekoneri\yemekoneri\yemekoneri\Views\Home\FoodDetail.cshtml"
       Write(Model.YemekAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        <hr />\r\n        <p>\r\n            ");
#nullable restore
#line 14 "F:\User\Desktop\test apps\yemekoneri\yemekoneri\yemekoneri\yemekoneri\Views\Home\FoodDetail.cshtml"
       Write(Model.YemekAciklamasi);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </p>
    </div>
    <hr />
    <h3>Yorumlar Ekle</h3>
    <div class=""row justify-content-center"">
        <div class=""col-md-6"">
            <div class=""form-group"">
                <label for=""YorumMail"">Mail Adresi</label>
                <input type=""text""
                       id=""YorumMail""
                       name=""YorumMail""
                       class=""form-control"" />
            </div>
        </div>
    </div>

    <div class=""row justify-content-center"">
        <div class=""col-md-6"">
            <div class=""form-group"">
                <label for=""YorumAciklama"">Yorum İçerik</label>
                <textarea name=""YorumAciklama""
                          class=""form-control""
                          id=""YorumAciklama""
                          cols=""30""
                          rows=""10""></textarea>
                <button onclick=""SendComment()"" class=""btn btn-outline-success btn-block mt-2"">
                    <i class=""fas fa-pen-alt""></i>&nbsp;Yoru");
            WriteLiteral(@"mu Gönder
                </button>
            </div>
        </div>
    </div>
    <hr />
    <div class=""row mb-4 d-none"" id=""commentExample"">
        <div class=""col-md-2 text-right"">
            <i class=""fas fa-user-alt personIcon""></i>
        </div>
        <div class=""col-md-10"">
            <h3 class=""yorumKisi"">Kişi İsmi</h3>
            <p class=""yorumAciklama"">
                Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                Praesentium, tenetur blanditiis atque quis aliquid saepe.
            </p>
        </div>
    </div>
</div>  
");
            DefineSection("Scripts", async() => {
                WriteLiteral(" \r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94dd3710454f5d01987b3e1cac65aee60b5bac3c6701", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<yemekoneri.Entities.Yemek> Html { get; private set; }
    }
}
#pragma warning restore 1591
