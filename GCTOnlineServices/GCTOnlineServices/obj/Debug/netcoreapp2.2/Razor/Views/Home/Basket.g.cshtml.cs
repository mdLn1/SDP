#pragma checksum "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9761ae1bcfe14cbf124f66c9e69564461cb4e944"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Basket), @"mvc.1.0.view", @"/Views/Home/Basket.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Basket.cshtml", typeof(AspNetCore.Views_Home_Basket))]
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
#line 2 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9761ae1bcfe14cbf124f66c9e69564461cb4e944", @"/Views/Home/Basket.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"667e0bd75593464ac890ddf764a3ddd8b525a472", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Basket : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewBasket>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", new global::Microsoft.AspNetCore.Html.HtmlString("GET"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteTicket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(97, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
  
    ViewData["Title"] = "Basket";

#line default
#line hidden
            BeginContext(141, 21, true);
            WriteLiteral("\r\n<h1>Basket</h1>\r\n\r\n");
            EndContext();
#line 11 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
 if (SignInManager.IsSignedIn(User))
{

    

#line default
#line hidden
#line 14 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
     if (User.IsInRole("AgencyOrClub"))
    {
        

#line default
#line hidden
#line 16 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
         if (Model.ApprovedDiscounts != true)
        {


#line default
#line hidden
            BeginContext(313, 196, true);
            WriteLiteral("            <div class=\"alert alert-warning\">\r\n                <strong>Warning!</strong>\r\n                Discounts were not approved for this account yet. Please contact us!\r\n            </div>\r\n");
            EndContext();
#line 23 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
        }

#line default
#line hidden
#line 23 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
         
    }

#line default
#line hidden
#line 24 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
     
}

#line default
#line hidden
            BeginContext(530, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 27 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
 if (@Model.tickets.Count > 0)
{

#line default
#line hidden
            BeginContext(567, 37, true);
            WriteLiteral("    <div class=\"container\">\r\n        ");
            EndContext();
            BeginContext(604, 3938, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9761ae1bcfe14cbf124f66c9e69564461cb4e9447737", async() => {
                BeginContext(668, 22, true);
                WriteLiteral("\r\n            <br />\r\n");
                EndContext();
#line 32 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
             foreach (var item in Model.tickets)
            {

#line default
#line hidden
                BeginContext(755, 83, true);
                WriteLiteral("                <div class=\"jumbotron\">\r\n                    <h1 class=\"display-4\">");
                EndContext();
                BeginContext(839, 20, false);
#line 35 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                                     Write(item.PerformanceName);

#line default
#line hidden
                EndContext();
                BeginContext(859, 50, true);
                WriteLiteral("</h1>\r\n                    <p class=\"lead\"><span> ");
                EndContext();
                BeginContext(910, 20, false);
#line 36 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                                      Write(item.PerformanceTime);

#line default
#line hidden
                EndContext();
                BeginContext(930, 88, true);
                WriteLiteral(" </span></p>\r\n                    <hr class=\"my-4\">\r\n                    <p><span>Seat: ");
                EndContext();
                BeginContext(1019, 15, false);
#line 38 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                              Write(item.SeatLetter);

#line default
#line hidden
                EndContext();
                BeginContext(1034, 21, true);
                WriteLiteral("  </span><span> Row: ");
                EndContext();
                BeginContext(1056, 14, false);
#line 38 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                                                                   Write(item.RowNumber);

#line default
#line hidden
                EndContext();
                BeginContext(1070, 81, true);
                WriteLiteral(" </span></p>\r\n                    <p>\r\n                        <span>Chair Cost: ");
                EndContext();
                BeginContext(1152, 10, false);
#line 40 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                                     Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(1162, 75, true);
                WriteLiteral(" </span><span>&#163;</span>\r\n                    </p>\r\n                    ");
                EndContext();
                BeginContext(1237, 134, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9761ae1bcfe14cbf124f66c9e69564461cb4e94410708", async() => {
                    BeginContext(1325, 42, true);
                    WriteLiteral("<span class=\"btn btn-danger\">Delete</span>");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 42 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                                                                                      WriteLiteral(item.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1371, 26, true);
                WriteLiteral("\r\n                </div>\r\n");
                EndContext();
#line 44 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
            }

#line default
#line hidden
                BeginContext(1412, 46, true);
                WriteLiteral("\r\n\r\n\r\n            <div class=\"form-group\">\r\n\r\n");
                EndContext();
#line 50 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                 if (SignInManager.IsSignedIn(User))
                {

                    

#line default
#line hidden
#line 53 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                     if (User.IsInRole("Customer") || User.IsInRole("AgencyOrClub"))
                    {
                        

#line default
#line hidden
#line 55 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                         if (Model.SavedCard == null)
                        {

#line default
#line hidden
                BeginContext(1724, 122, true);
                WriteLiteral("                            <div class=\"form-control\">\r\n                                <span>Remember my details </span> ");
                EndContext();
                BeginContext(1847, 43, false);
#line 58 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                                                             Write(Html.CheckBoxFor(model => model.RememberMe));

#line default
#line hidden
                EndContext();
                BeginContext(1890, 38, true);
                WriteLiteral("\r\n                            </div>\r\n");
                EndContext();
#line 60 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                        }

#line default
#line hidden
                BeginContext(1955, 226, true);
                WriteLiteral("                        <div class=\"form-group\">\r\n                            <label class=\"control-label\">Shipping :</label>\r\n                            <p>\r\n                                <select name=\"selectedDelivery\">\r\n");
                EndContext();
#line 65 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                                     foreach (var delivery in Model.DeliveryMethod)
                                    {

#line default
#line hidden
                BeginContext(2305, 40, true);
                WriteLiteral("                                        ");
                EndContext();
                BeginContext(2345, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9761ae1bcfe14cbf124f66c9e69564461cb4e94416090", async() => {
                    BeginContext(2372, 8, false);
#line 67 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                                                             Write(delivery);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 67 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                                           WriteLiteral(delivery);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2389, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 68 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                                    }

#line default
#line hidden
                BeginContext(2430, 109, true);
                WriteLiteral("                                </select>\r\n                            </p>\r\n                        </div>\r\n");
                EndContext();
#line 72 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"

                    }

#line default
#line hidden
#line 76 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                     if (!User.IsInRole("Customer") && !User.IsInRole("AgencyOrClub"))
                    {

#line default
#line hidden
                BeginContext(2679, 288, true);
                WriteLiteral(@"                        <div class=""form-group"" id=""custName"">
                            <label> Customer Name: </label>
                            <input name=""CustomerName"" placeholder=""Please Enter Customer Full Name here"" class=""form-control"" />
                        </div>
");
                EndContext();
#line 82 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"

                    }

#line default
#line hidden
#line 83 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                     

                }

#line default
#line hidden
                BeginContext(3013, 76, true);
                WriteLiteral("            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
                EndContext();
                BeginContext(3090, 36, false);
#line 89 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
           Write(Html.HiddenFor(model => model.Total));

#line default
#line hidden
                EndContext();
                BeginContext(3126, 37, true);
                WriteLiteral("\r\n                <label>Total Cost: ");
                EndContext();
                BeginContext(3164, 11, false);
#line 90 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                              Write(Model.Total);

#line default
#line hidden
                EndContext();
                BeginContext(3175, 50, true);
                WriteLiteral(" <span>&#163;</span></label>\r\n            </div>\r\n");
                EndContext();
#line 92 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
             if (User.IsInRole("SalesStaff") || User.IsInRole("MAnager"))
            {

#line default
#line hidden
                BeginContext(3315, 149, true);
                WriteLiteral("                <script src=\"//checkout.stripe.com/v2/checkout.js\"\r\n                        class=\"stripe-button\"\r\n                        data-key=\"");
                EndContext();
                BeginContext(3465, 27, false);
#line 96 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                             Write(Stripe.Value.PublishableKey);

#line default
#line hidden
                EndContext();
                BeginContext(3492, 187, true);
                WriteLiteral("\"\r\n                        data-locale=\"auto\"\r\n                        data-description=\"GCT Theatre\"\r\n                        data-allow-remember-me=\"false\">\r\n                </script>\r\n");
                EndContext();
#line 101 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
            }

#line default
#line hidden
                BeginContext(3694, 16, true);
                WriteLiteral("                ");
                EndContext();
#line 102 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                 if (User.IsInRole("Customer") || User.IsInRole("AgencyOrClub"))
                {
                    

#line default
#line hidden
#line 104 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                     if (Model.SavedCard != null)
                    {

#line default
#line hidden
                BeginContext(3869, 45, true);
                WriteLiteral("                        <button type=\"submit\"");
                EndContext();
                BeginWriteAttribute("formaction", " formaction=\'", 3914, "\'", 3961, 1);
#line 106 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
WriteAttributeValue("", 3927, Url.Action("UseSavedCard","Home"), 3927, 34, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3962, 31, true);
                WriteLiteral(">Pay with Saved Card</button>\r\n");
                EndContext();
#line 107 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                    }
                    else
                    {

#line default
#line hidden
                BeginContext(4065, 173, true);
                WriteLiteral("                        <script src=\"//checkout.stripe.com/v2/checkout.js\"\r\n                                class=\"stripe-button\"\r\n                                data-key=\"");
                EndContext();
                BeginContext(4239, 27, false);
#line 112 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                                     Write(Stripe.Value.PublishableKey);

#line default
#line hidden
                EndContext();
                BeginContext(4266, 219, true);
                WriteLiteral("\"\r\n                                data-locale=\"auto\"\r\n                                data-description=\"GCT Theatre\"\r\n                                data-allow-remember-me=\"false\">\r\n                        </script>\r\n");
                EndContext();
#line 117 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                    }

#line default
#line hidden
#line 117 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
                     
                }

#line default
#line hidden
                BeginContext(4527, 8, true);
                WriteLiteral("        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4542, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 121 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(4568, 36, true);
            WriteLiteral("    <h2>Your basket is empty!</h2>\r\n");
            EndContext();
#line 125 "D:\repo\GCTOnlineServices\GCTOnlineServices\Views\Home\Basket.cshtml"
}

#line default
#line hidden
            BeginContext(4607, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IOptions<StripeSettings> Stripe { get; private set; }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ViewBasket> Html { get; private set; }
    }
}
#pragma warning restore 1591
