#pragma checksum "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d689182339269d1bf6d1cb681dfa1b2e0fb2038"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Delete), @"mvc.1.0.view", @"/Views/Product/Delete.cshtml")]
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
#line 1 "C:\EcommerceApp\UILayer\Views\_ViewImports.cshtml"
using UILayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\EcommerceApp\UILayer\Views\_ViewImports.cshtml"
using UILayer.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d689182339269d1bf6d1cb681dfa1b2e0fb2038", @"/Views/Product/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c17c26a0cf4c903ad8b8f2b1531088e5948c7add", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DomainLayer.Product>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("    <h3>Are you sure you want to delete this?</h3>\r\n    <div>\r\n        <hr />\r\n");
#nullable restore
#line 11 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
         using (Html.BeginForm())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <dl class=\"dl-horizontal\">\r\n        ");
#nullable restore
#line 15 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
   Write(Html.HiddenFor(model => model.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n        <dt>\r\n            ");
#nullable restore
#line 26 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.productName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 30 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
       Write(Html.DisplayFor(model => model.productName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n\r\n        <dt>\r\n            ");
#nullable restore
#line 35 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.productModel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 39 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
       Write(Html.DisplayFor(model => model.productModel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
#nullable restore
#line 43 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.productPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 47 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
       Write(Html.DisplayFor(model => model.productPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
#nullable restore
#line 51 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            <input type=\"image\" id=\"image\" />\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
#nullable restore
#line 58 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 62 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
       Write(Html.DisplayFor(model => model.description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n\r\n    </dl>\r\n");
            WriteLiteral("    <div class=\"form-actions no-color\">\r\n        ");
#nullable restore
#line 69 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
   Write(Html.ActionLink("Delete", "Delete", new { id = Model.id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n        ");
#nullable restore
#line 70 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
   Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 72 "C:\EcommerceApp\UILayer\Views\Product\Delete.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
            WriteLiteral("    <script>\r\n        $(document).ready(function() {\r\n            $(\'#delete\').click(function(){\r\n                alert(\"Are you sure to delete\");\r\n            });\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DomainLayer.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591