#pragma checksum "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\Reviews\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc57c15d0d4a4ff42f77c053abfab74e788913c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reviews_Details), @"mvc.1.0.view", @"/Views/Reviews/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Reviews/Details.cshtml", typeof(AspNetCore.Views_Reviews_Details))]
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
#line 1 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\_ViewImports.cshtml"
using GCTProject;

#line default
#line hidden
#line 2 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\_ViewImports.cshtml"
using GCTProject.Models;

#line default
#line hidden
#line 3 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\_ViewImports.cshtml"
using GCTProject.Models.ViewModels;

#line default
#line hidden
#line 4 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\_ViewImports.cshtml"
using GCTProject.Data;

#line default
#line hidden
#line 5 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc57c15d0d4a4ff42f77c053abfab74e788913c0", @"/Views/Reviews/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52d2dad6e50867d719d1c40645e1215c6484dd69", @"/Views/_ViewImports.cshtml")]
    public class Views_Reviews_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GCTProject.Data.Review>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(31, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\Reviews\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(76, 129, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Review</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(206, 44, false);
#line 14 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\Reviews\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(250, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(314, 40, false);
#line 17 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\Reviews\Details.cshtml"
       Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(354, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(417, 43, false);
#line 20 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\Reviews\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Comment));

#line default
#line hidden
            EndContext();
            BeginContext(460, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(524, 39, false);
#line 23 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\Reviews\Details.cshtml"
       Write(Html.DisplayFor(model => model.Comment));

#line default
#line hidden
            EndContext();
            BeginContext(563, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(626, 40, false);
#line 26 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\Reviews\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(666, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(730, 36, false);
#line 29 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\Reviews\Details.cshtml"
       Write(Html.DisplayFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(766, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(829, 47, false);
#line 32 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\Reviews\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Performance));

#line default
#line hidden
            EndContext();
            BeginContext(876, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(940, 46, false);
#line 35 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\Reviews\Details.cshtml"
       Write(Html.DisplayFor(model => model.Performance.Id));

#line default
#line hidden
            EndContext();
            BeginContext(986, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1049, 40, false);
#line 38 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\Reviews\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.User));

#line default
#line hidden
            EndContext();
            BeginContext(1089, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1153, 39, false);
#line 41 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\Reviews\Details.cshtml"
       Write(Html.DisplayFor(model => model.User.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1192, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1240, 68, false);
#line 46 "C:\Users\acer\source\repos\GCTProject\GCTProject\Views\Reviews\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1308, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1316, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc57c15d0d4a4ff42f77c053abfab74e788913c08932", async() => {
                BeginContext(1338, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1354, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GCTProject.Data.Review> Html { get; private set; }
    }
}
#pragma warning restore 1591