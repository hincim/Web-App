#pragma checksum "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f6053c541dd446c6551a7ea082ba2ca239bd322"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_RoleEdit), @"mvc.1.0.view", @"/Views/Admin/RoleEdit.cshtml")]
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
#nullable restore
#line 7 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\_ViewImports.cshtml"
using ShopApp.WebUI.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f6053c541dd446c6551a7ea082ba2ca239bd322", @"/Views/Admin/RoleEdit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d61ac67db0aadf51cea562572c1e023069f0e83", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_RoleEdit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleDetails>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RoleEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1 class=\"h3\">Edit Role</h1>\r\n<hr>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f6053c541dd446c6551a7ea082ba2ca239bd3225441", async() => {
                WriteLiteral("\r\n            <input type=\"hidden\" name=\"RoleId\"");
                BeginWriteAttribute("value", " value=\"", 218, "\"", 240, 1);
#nullable restore
#line 10 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
WriteAttributeValue("", 226, Model.Role.Id, 226, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            <input type=\"hidden\" name=\"RoleName\"");
                BeginWriteAttribute("value", " value=\"", 294, "\"", 318, 1);
#nullable restore
#line 11 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
WriteAttributeValue("", 302, Model.Role.Name, 302, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            <h6 bg-info text-white p-1>Add to ");
#nullable restore
#line 12 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
                                         Write(Model.Role.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n            <table class=\"table table-bordered table-sm\">\r\n");
#nullable restore
#line 14 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
                 if (Model.NonMembers.Count() == 0)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\n                        <td colspan=\"2\">Bütün kullanıcılar role ait.</td>\r\n                    </tr>\r\n");
#nullable restore
#line 19 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
                     foreach (var nonMember in Model.NonMembers)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\n                            <td>");
#nullable restore
#line 25 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
                           Write(nonMember.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td style =\"width:150px;\">\r\n                                <input type=\"checkbox\" name=\"IdsToAdd\"");
                BeginWriteAttribute("value", " value=\"", 1010, "\"", 1031, 1);
#nullable restore
#line 27 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
WriteAttributeValue("", 1018, nonMember.Id, 1018, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                            </td>\r\n                        </tr>\n");
#nullable restore
#line 30 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </table>\r\n\r\n            <hr>\r\n\r\n            <h6 bg-info text-white p-1>Remove from ");
#nullable restore
#line 36 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
                                              Write(Model.Role.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n            <table class=\"table table-bordered table-sm\">\r\n");
#nullable restore
#line 38 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
                 if (Model.Members.Count() == 0)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td colspan=\"2\">Role ait kullanıcı yok.</td>\r\n                    </tr>\r\n");
#nullable restore
#line 43 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
                     foreach (var member in Model.Members)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 49 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
                           Write(member.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td style=\"width:150px;\">\r\n                                <input type=\"checkbox\" name=\"IdsToDelete\"");
                BeginWriteAttribute("value", " value=\"", 1867, "\"", 1885, 1);
#nullable restore
#line 51 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
WriteAttributeValue("", 1875, member.Id, 1875, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 54 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\hakan.DESKTOP-99I88G4\OneDrive\Masaüstü\web_gelistirme\.Net Core\asp.net_core_mvc\ShopApp\ShopApp.WebUI\Views\Admin\RoleEdit.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </table>\r\n            <button type=\"submit\" class=\"btn btn-primary\">Rolü Değişikliğini Kaydet</button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleDetails> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
