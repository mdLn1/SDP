#pragma checksum "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8becfd7c9e21fa62f8aae86c2fcf4b48db899375"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_BuyNow), @"mvc.1.0.view", @"/Views/Home/BuyNow.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/BuyNow.cshtml", typeof(AspNetCore.Views_Home_BuyNow))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8becfd7c9e21fa62f8aae86c2fcf4b48db899375", @"/Views/Home/BuyNow.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"667e0bd75593464ac890ddf764a3ddd8b525a472", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_BuyNow : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TicketAndReceipt>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PrintTickets", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary active"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(25, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
  
    ViewData["Title"] = "BuyNow";

#line default
#line hidden
            BeginContext(69, 123, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"alert alert-success\">\r\n        <strong>Success!</strong> You succesfully bought ");
            EndContext();
            BeginContext(193, 21, false);
#line 9 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
                                                    Write(Model.Tickets.Count());

#line default
#line hidden
            EndContext();
            BeginContext(214, 83, true);
            WriteLiteral(" tickets!\r\n    </div>\r\n    <div class=\"alert alert-success\">\r\n        Dear <strong>");
            EndContext();
            BeginContext(298, 16, false);
#line 12 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
                Write(Model.PersonName);

#line default
#line hidden
            EndContext();
            BeginContext(314, 115, true);
            WriteLiteral("</strong>, thanks for shopping with us!\r\n    </div>\r\n    <div class=\"alert alert-success\">\r\n        You just paid: ");
            EndContext();
            BeginContext(430, 15, false);
#line 15 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
                  Write(Model.TotalCost);

#line default
#line hidden
            EndContext();
            BeginContext(445, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 16 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
         if (Model.DiscountApplied)
        {

#line default
#line hidden
            BeginContext(495, 36, true);
            WriteLiteral("            <strong>Today you saved ");
            EndContext();
            BeginContext(532, 11, false);
#line 18 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
                               Write(Model.Saved);

#line default
#line hidden
            EndContext();
            BeginContext(543, 11, true);
            WriteLiteral("</strong>\r\n");
            EndContext();
#line 19 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
        }

#line default
#line hidden
            BeginContext(565, 14, true);
            WriteLiteral("    </div>\r\n\r\n");
            EndContext();
#line 22 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
     if (SignInManager.IsSignedIn(User))
    {
        

#line default
#line hidden
#line 24 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
         if (User.IsInRole("SalesStaff") || User.IsInRole("Manager"))
        {

#line default
#line hidden
            BeginContext(710, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(722, 151, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8becfd7c9e21fa62f8aae86c2fcf4b48db8993757419", async() => {
                BeginContext(832, 37, true);
                WriteLiteral("\r\n                Print\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 26 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
                                           WriteLiteral(Model.OrderId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(873, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 30 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
        }

#line default
#line hidden
#line 30 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
         
    }

#line default
#line hidden
            BeginContext(893, 37, true);
            WriteLiteral("\r\n</div>\r\n<div class=\"container\">\r\n\r\n");
            EndContext();
#line 36 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
     for (int i = 0; i < Model.Tickets.Count(); i++)
    {

#line default
#line hidden
            BeginContext(991, 130, true);
            WriteLiteral("        <div class=\"jumbotron\">\r\n            <h1 class=\"display-4\">\r\n                <span class=\"font-weight-bold\">Play :</span> ");
            EndContext();
            BeginContext(1122, 42, false);
#line 40 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
                                                        Write(Model.Tickets.ElementAt(i).PerformanceName);

#line default
#line hidden
            EndContext();
            BeginContext(1164, 72, true);
            WriteLiteral("\r\n                <br />   <span class=\"font-weight-bold\">Date :</span> ");
            EndContext();
            BeginContext(1237, 42, false);
#line 41 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
                                                                 Write(Model.Tickets.ElementAt(i).PerformanceTime);

#line default
#line hidden
            EndContext();
            BeginContext(1279, 66, true);
            WriteLiteral("\r\n            </h1>\r\n            <p class=\"lead\"><span>Customer : ");
            EndContext();
            BeginContext(1346, 16, false);
#line 43 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
                                        Write(Model.PersonName);

#line default
#line hidden
            EndContext();
            BeginContext(1362, 129, true);
            WriteLiteral("</span></p>\r\n            <hr class=\"my-4\">\r\n            <p>\r\n                <span class=\"font-weight-bold\">Row Number : </span> ");
            EndContext();
            BeginContext(1492, 36, false);
#line 46 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
                                                               Write(Model.Tickets.ElementAt(i).RowNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1528, 77, true);
            WriteLiteral(" <br />\r\n                <span class=\"font-weight-bold\">Seat Letter :</span> ");
            EndContext();
            BeginContext(1606, 37, false);
#line 47 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
                                                               Write(Model.Tickets.ElementAt(i).SeatLetter);

#line default
#line hidden
            EndContext();
            BeginContext(1643, 66, true);
            WriteLiteral("\r\n            </p>\r\n            <p>\r\n                <span>Price: ");
            EndContext();
            BeginContext(1710, 32, false);
#line 50 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
                        Write(Model.Tickets.ElementAt(i).Price);

#line default
#line hidden
            EndContext();
            BeginContext(1742, 44, true);
            WriteLiteral(" </span>\r\n            </p>\r\n        </div>\r\n");
            EndContext();
#line 53 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\BuyNow.cshtml"
    }

#line default
#line hidden
            BeginContext(1793, 8, true);
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TicketAndReceipt> Html { get; private set; }
    }
}
#pragma warning restore 1591
