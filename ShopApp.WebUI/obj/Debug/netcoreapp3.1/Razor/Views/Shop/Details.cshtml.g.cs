#pragma checksum "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shop\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24051333c29b2dc96a6fd14974d92acd80c7a3fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Details), @"mvc.1.0.view", @"/Views/Shop/Details.cshtml")]
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
#line 2 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\_ViewImports.cshtml"
using ShopApp.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\_ViewImports.cshtml"
using ShopApp.WebUI.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\_ViewImports.cshtml"
using ShopApp.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\_ViewImports.cshtml"
using ShopApp.WebUI.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24051333c29b2dc96a6fd14974d92acd80c7a3fb", @"/Views/Shop/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b9f2203b70aa5bf031a51a01c3e4a0faa9c52bd", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shop_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductDetailModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "list", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-link p-0 mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "24051333c29b2dc96a6fd14974d92acd80c7a3fb5592", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 94, "~/img/", 94, 6, true);
#nullable restore
#line 5 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shop\Details.cshtml"
AddHtmlAttributeValue("", 100, Model.Product.ImageUrl, 100, 23, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        <h5 class=\"mb-3\">");
#nullable restore
#line 8 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shop\Details.cshtml"
                    Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5> <hr>\r\n\r\n");
#nullable restore
#line 10 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shop\Details.cshtml"
         foreach (var category in Model.Categories)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24051333c29b2dc96a6fd14974d92acd80c7a3fb7930", async() => {
#nullable restore
#line 12 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shop\Details.cshtml"
                                                                                                                   Write(category.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-category", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 12 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shop\Details.cshtml"
                                                               WriteLiteral(category.Url);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["category"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-category", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["category"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 13 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shop\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"mb-3\">\r\n            <h4 class=\"text-primary mb-3\">");
#nullable restore
#line 16 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shop\Details.cshtml"
                                     Write(Model.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("<i class=\"fas fa-lira-sign\"></i></h4>\r\n            <button type=\"submit\" class=\"btn btn-primary btn-lg\">Add to Cart</button>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"row\">\r\n    <div class=\"col-md-12 p-5\">\r\n        <p class=\"p-3\">");
#nullable restore
#line 23 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shop\Details.cshtml"
                  Write(Html.Raw(Model.Product.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductDetailModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
