#pragma checksum "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shared\Components\Categories\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc9b9b30d0408d5c267adfb0f8bcc5f4d65997c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Categories_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Categories/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc9b9b30d0408d5c267adfb0f8bcc5f4d65997c5", @"/Views/Shared/Components/Categories/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b9f2203b70aa5bf031a51a01c3e4a0faa9c52bd", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_Categories_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Category>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "list", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"list-group\">\r\n   <a href=\"/products\" class=\"list-group-item list-group-item-action\">Tüm Kategoriler</a>\r\n\r\n");
#nullable restore
#line 6 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shared\Components\Categories\Default.cshtml"
     foreach (var category in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("         ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc9b9b30d0408d5c267adfb0f8bcc5f4d65997c55236", async() => {
#nullable restore
#line 12 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shared\Components\Categories\Default.cshtml"
                                                               Write(category.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-category", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 10 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shared\Components\Categories\Default.cshtml"
                 WriteLiteral(category.Url);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["category"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-category", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["category"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 313, "list-group-item", 313, 15, true);
            AddHtmlAttributeValue(" ", 328, "list-group-item-action", 329, 23, true);
#nullable restore
#line 11 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shared\Components\Categories\Default.cshtml"
AddHtmlAttributeValue("\r\n        ", 351, ViewBag.SelectedCategory == category.Url ? "active": "", 361, 58, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 13 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Shared\Components\Categories\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Category>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
