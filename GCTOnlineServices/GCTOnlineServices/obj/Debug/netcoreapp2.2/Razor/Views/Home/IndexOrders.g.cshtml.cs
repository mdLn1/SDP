#pragma checksum "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58ec347c4c24d28deba785cbfd82eef8109dcde8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_IndexOrders), @"mvc.1.0.view", @"/Views/Home/IndexOrders.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/IndexOrders.cshtml", typeof(AspNetCore.Views_Home_IndexOrders))]
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
#line 1 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\_ViewImports.cshtml"
using GCTOnlineServices;

#line default
#line hidden
#line 2 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\_ViewImports.cshtml"
using GCTOnlineServices.Models;

#line default
#line hidden
#line 3 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\_ViewImports.cshtml"
using GCTOnlineServices.Models.OOPModels;

#line default
#line hidden
#line 4 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\_ViewImports.cshtml"
using GCTOnlineServices.Models.ViewModels;

#line default
#line hidden
#line 5 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 6 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\_ViewImports.cshtml"
using GCTOnlineServices.Helpers;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58ec347c4c24d28deba785cbfd82eef8109dcde8", @"/Views/Home/IndexOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"667e0bd75593464ac890ddf764a3ddd8b525a472", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_IndexOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AllOrders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary active"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OrderedTickets", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PrintTickets", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(27, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 4 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
  
    ViewData["Title"] = "Orders";

#line default
#line hidden
            BeginContext(73, 26, true);
            WriteLiteral("\r\n<h1>Your Orders</h1>\r\n\r\n");
            EndContext();
#line 10 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
 if (SignInManager.IsSignedIn(User))
{
    

#line default
#line hidden
#line 12 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
     if (User.IsInRole("SalesStaff") || User.IsInRole("Manager"))
    {

#line default
#line hidden
            BeginContext(214, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(222, 112, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58ec347c4c24d28deba785cbfd82eef8109dcde85846", async() => {
                BeginContext(291, 39, true);
                WriteLiteral("\r\n            Show all Orders\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(334, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 18 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
    }

#line default
#line hidden
#line 18 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
     
}

#line default
#line hidden
            BeginContext(346, 86, true);
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(433, 38, false);
#line 25 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(471, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(527, 45, false);
#line 28 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.OrderTime));

#line default
#line hidden
            EndContext();
            BeginContext(572, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(628, 50, false);
#line 31 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.DeliveryMethod));

#line default
#line hidden
            EndContext();
            BeginContext(678, 21, true);
            WriteLiteral("\r\n            </th>\r\n");
            EndContext();
#line 33 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
             if (User.IsInRole("Manager") || User.IsInRole("SalesStaff"))
            {


#line default
#line hidden
            BeginContext(791, 42, true);
            WriteLiteral("                <th>\r\n                    ");
            EndContext();
            BeginContext(834, 45, false);
#line 37 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
               Write(Html.DisplayNameFor(model => model.IsPrinted));

#line default
#line hidden
            EndContext();
            BeginContext(879, 25, true);
            WriteLiteral("\r\n                </th>\r\n");
            EndContext();
#line 39 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
            }

#line default
#line hidden
            BeginContext(919, 65, true);
            WriteLiteral("            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 44 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1033, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1082, 37, false);
#line 48 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1119, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1175, 44, false);
#line 51 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
           Write(Html.DisplayFor(modelItem => item.OrderTime));

#line default
#line hidden
            EndContext();
            BeginContext(1219, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1275, 49, false);
#line 54 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
           Write(Html.DisplayFor(modelItem => item.DeliveryMethod));

#line default
#line hidden
            EndContext();
            BeginContext(1324, 21, true);
            WriteLiteral("\r\n            </td>\r\n");
            EndContext();
#line 56 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
             if (User.IsInRole("Manager") || User.IsInRole("SalesStaff"))
            {

#line default
#line hidden
            BeginContext(1435, 22, true);
            WriteLiteral("                <td>\r\n");
            EndContext();
#line 59 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
                     if (item.IsPrinted)
                    {

#line default
#line hidden
            BeginContext(1522, 141, true);
            WriteLiteral("                        <div class=\"alert alert-success\">\r\n                            <span>Printed</span>\r\n                        </div>\r\n");
            EndContext();
#line 64 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(1735, 144, true);
            WriteLiteral("                        <div class=\"alert alert-danger\">\r\n                            <span>Not Printed</span>\r\n                        </div>\r\n");
            EndContext();
#line 70 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
                    }

#line default
#line hidden
            BeginContext(1902, 23, true);
            WriteLiteral("                </td>\r\n");
            EndContext();
#line 72 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
            }

#line default
#line hidden
            BeginContext(1940, 36, true);
            WriteLiteral("            <td>\r\n\r\n                ");
            EndContext();
            BeginContext(1976, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58ec347c4c24d28deba785cbfd82eef8109dcde813307", async() => {
                BeginContext(2031, 13, true);
                WriteLiteral("Order details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 75 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
                                                 WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2048, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 76 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
                 if (SignInManager.IsSignedIn(User))
                {
                    if (User.IsInRole("SalesStaff") || User.IsInRole("Manager"))
                    {

#line default
#line hidden
            BeginContext(2228, 64, true);
            WriteLiteral("                        <span>|</span>\r\n                        ");
            EndContext();
            BeginContext(2292, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58ec347c4c24d28deba785cbfd82eef8109dcde816110", async() => {
                BeginContext(2345, 5, true);
                WriteLiteral("Print");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 81 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
                                                       WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2354, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 82 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(2398, 34, true);
            WriteLiteral("            </td>\r\n        </tr>\r\n");
            EndContext();
#line 86 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\IndexOrders.cshtml"
        }

#line default
#line hidden
            BeginContext(2443, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
