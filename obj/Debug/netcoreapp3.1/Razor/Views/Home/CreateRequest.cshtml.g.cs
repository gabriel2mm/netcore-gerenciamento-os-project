#pragma checksum "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3f1a244b31f2c4f4f54e1255281a728341baa81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CreateRequest), @"mvc.1.0.view", @"/Views/Home/CreateRequest.cshtml")]
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
#line 1 "C:\Users\gabri\source\repos\GDR\GDR\Views\_ViewImports.cshtml"
using GDR;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gabri\source\repos\GDR\GDR\Views\_ViewImports.cshtml"
using GDR.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
using GDR.Enumerators;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
using GDR.Models.ModelsForViews;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3f1a244b31f2c4f4f54e1255281a728341baa81", @"/Views/Home/CreateRequest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8c019d0c725705bb2e7e3f09db2f72ccb8ac556", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_CreateRequest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RequestViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
  
    ViewData["Title"] = "Criar requisição";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"jumbotron\">\r\n        <div class=\"row\">\r\n            <h1>Criar Requisição</h1>\r\n        </div>\r\n\r\n");
#nullable restore
#line 19 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
         using (Html.BeginForm())
        {
            Html.AntiForgeryToken();


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group\">\r\n                <label>Requisição para usuário: ");
#nullable restore
#line 24 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
                                           Write(_userManager.GetUserAsync(User).Result.Login);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 28 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
           Write(Html.LabelFor(model => model.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 29 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
           Write(Html.DropDownListFor(model => model.Type, Html.GetEnumSelectList<Types>(), null, new { @class ="form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <span class=\"text-danger\">");
#nullable restore
#line 30 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
                                     Write(Html.ValidationMessageFor(model => model.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 34 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
           Write(Html.LabelFor(model => model.Equipament));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 35 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
           Write(Html.TextBoxFor(model => model.Equipament, "", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <span class=\"text-danger\">");
#nullable restore
#line 36 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
                                     Write(Html.ValidationMessageFor(model => model.Equipament));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 40 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
           Write(Html.LabelFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 41 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
           Write(Html.TextAreaFor(model => model.Description, 5, 5, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <span class=\"text-danger\">");
#nullable restore
#line 42 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
                                     Write(Html.ValidationMessageFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n");
            WriteLiteral("            <button type=\"submit\" class=\"btn btn-success\">Criar Requisição</button>\r\n");
#nullable restore
#line 46 "C:\Users\gabri\source\repos\GDR\GDR\Views\Home\CreateRequest.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<User> _userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RequestViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
