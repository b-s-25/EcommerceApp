#pragma checksum "D:\Final DemoProject\EcommerceApp\UILayer\Views\Shared\Admin\_footer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a9b88e317f6846b46ccd72bfe8478b0dd911160"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Admin__footer), @"mvc.1.0.view", @"/Views/Shared/Admin/_footer.cshtml")]
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
#line 1 "D:\Final DemoProject\EcommerceApp\UILayer\Views\_ViewImports.cshtml"
using UILayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Final DemoProject\EcommerceApp\UILayer\Views\_ViewImports.cshtml"
using UILayer.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a9b88e317f6846b46ccd72bfe8478b0dd911160", @"/Views/Shared/Admin/_footer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c17c26a0cf4c903ad8b8f2b1531088e5948c7add", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Admin__footer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/MobiZone-logos_black.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<style>
footer {
  display: flex;
  flex-direction: row;
  border-top: 1px solid;
  flex-wrap: wrap;
  margin-top:500px;
}
footer h5 a {
  display: flex;
  flex-direction: column;
}
footer h5 a img {
  width: 100px;
}
footer h5 a span {
  text-align: center;
}
footer > ul {
  margin: 0 auto;
  margin-top: 20px;
}
footer > ul > li ul {
  margin-left: 10px;
}
footer div {
  border-top: 1px solid;
  flex: 0 0 100%;
  margin-top: 10px;
}
footer div p {
  text-align: center;
  padding: 10px;
}
 a{
    text-decoration:none;
}
li{
     list-style:none;
}
.about{
    margin-top:10px;
}
.privacy{
    margin-top:10px;
}
.contact{
    margin-top:10px;
}
                </style>
                 <footer>
            <h5>
                <a href=""#"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7a9b88e317f6846b46ccd72bfe8478b0dd9111604264", async() => {
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
            WriteLiteral(@" <span>MobiZone</span> </a>
            </h5>

            <ul>

                <li>
                    <a href=""#"">Company</a>
                    <ul>
                        <li class=""about""><a href=""#"">About</a></li>
                        <li class=""privacy""><a href=""#"">Privacy & Policy</a></li>
                        <li class=""contact""><a href=""#"">Contact Us</a></li>
                    </ul>
                </li>

            </ul>

            <div>
                <p><i class=""fa fa-copyright"" aria-hidden=""true""></i> Mobizone Pivate limited</p>
            </div>

        </footer>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
